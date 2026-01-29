# Bill Acceptor – Technical Flow & Implementation Guide

> Tài liệu kỹ thuật mô tả giao thức giao tiếp **PC ↔ Bill Acceptor** dạng 1-byte command,
> dùng để developer có thể **implement đúng flow, tránh lỗi logic tiền**.

---

## 1. Tổng quan

- Giao tiếp qua **Serial (COM)**
- Tốc độ phổ biến: `9600, Even parity, 8 data bits, 1 stop bit`
- **1 byte = 1 lệnh** (KHÔNG frame, KHÔNG checksum)
- Bill xử lý **theo state nội bộ**, PC phải tôn trọng thứ tự

---

## 2. Bảng byte & ý nghĩa

### 2.1. Byte từ Bill → PC

| Hex    | Ý nghĩa       | Ghi chú             |
| ------ | ------------- | ------------------- |
| `0x80` | READY         | Bill sẵn sàng       |
| `0x81` | BILL INSERTED | User đưa tiền vào   |
| `0x41` | 10,000        | Nhận diện mệnh giá  |
| `0x42` | 20,000        | Nhận diện mệnh giá  |
| `0x43` | 50,000        | Nhận diện mệnh giá  |
| `0x10` | BILL ACCEPTED | Đã nuốt tiền        |
| `0x8F` | ACK           | Xác nhận byte từ PC |

### 2.2. Byte từ PC → Bill

| Hex    | Ý nghĩa      |
| ------ | ------------ |
| `0x8F` | ACK          |
| `0x02` | ENABLE BILL  |
| `0x01` | ACCEPT BILL  |
| `0x00` | REJECT BILL  |
| `0x03` | DISABLE BILL |

---

## 3. Flow chuẩn (Happy Path)

### 3.1. Khởi động

```
Bill → PC : 0x80   (READY)
PC   → Bill: 0x8F   (ACK READY)
PC   → Bill: 0x02   (ENABLE)
```

---

### 3.2. Một chu kỳ nhận tiền

#### Bước 1 – User đưa tiền

```
Bill → PC : 0x81   (INSERT)
PC   → Bill: 0x8F   (ACK INSERT)
```

#### Bước 2 – Bill nhận diện mệnh giá

```
Bill → PC : 0x41 / 0x42 / ...
```

> ⚠️ **CHƯA ĐƯỢC CỘNG TIỀN Ở ĐÂY**

PC chỉ lưu tạm:

```
pendingValue = value;
```

#### Bước 3 – PC quyết định

```
PC → Bill : 0x01   (ACCEPT)
```

hoặc

```
PC → Bill : 0x00   (REJECT)
```

#### Bước 4 – Bill xác nhận

```
Bill → PC : 0x10   (ACCEPTED)
```

⛳ **CHỖ NÀY MỚI ĐƯỢC CỘNG TIỀN**

```
total += pendingValue;
pendingValue = 0;
```

---

### 3.3. Kết thúc giao dịch

Khi đủ tiền:

```
PC → Bill : 0x03   (DISABLE)
```

PC reset state / đóng COM.

---

## 4. State machine khuyến nghị (PC)

```
IDLE
 ↓ READY(80)
WAIT_INSERT
 ↓ INSERT(81)
WAIT_VALUE
 ↓ VALUE(41/42)
WAIT_ACCEPTED
 ↓ ACCEPTED(10)
COMMIT MONEY
```

---

## 5. Quy tắc vàng (RẤT QUAN TRỌNG)

### ✅ NÊN

- Chỉ cộng tiền khi nhận `0x10`
- ACK đúng byte (`READY`, `INSERT`)
- Tách từng byte, gửi riêng lẻ
- Có timeout cho mỗi state

### ❌ KHÔNG NÊN

- Cộng tiền khi thấy `0x41 / 0x42`
- Gửi value trước INSERT
- Gửi 2 value cho 1 INSERT
- Gộp `8F 02` thành 1 packet

---

## 6. Pseudocode chuẩn (PC)

```csharp
switch(state)
{
  case WaitingReady:
    if (b == 0x80)
    {
        Send(0x8F);
        Send(0x02);
        state = WaitingInsert;
    }
    break;

  case WaitingInsert:
    if (b == 0x81)
    {
        Send(0x8F);
        state = WaitingValue;
    }
    break;

  case WaitingValue:
    if (IsValue(b))
    {
        pending = Decode(b);
        Send(0x01);
        state = WaitingAccepted;
    }
    break;

  case WaitingAccepted:
    if (b == 0x10)
    {
        total += pending;
        pending = 0;
        state = WaitingInsert;
    }
    break;
}
```

---

## 7. Lỗi thường gặp & hậu quả

| Lỗi           | Hậu quả             |
| ------------- | ------------------- |
| Cộng tiền sớm | Mất tiền / lệch quỹ |
| Không ACK     | Bill treo           |
| Không timeout | Deadlock            |
| Sai thứ tự    | Bill reset          |

---

## 8. Kết luận

- `0x41/0x42` = **nhận diện**
- `0x10` = **tiền đã vào két**
- PC **phải làm chủ state machine**

Tài liệu này đủ để:

- Implement bill acceptor thật
- Viết fake/simulator
- Debug lỗi giao thức

---

## Banknote Denomination Bytes

Thiết bị **KHÔNG gửi số tiền trực tiếp**.  
Nó gửi **1 byte đại diện cho mệnh giá**, và **chỉ được phép cộng tiền sau khi nhận byte ACCEPTED**.

### Mapping byte → mệnh giá (VND)

| Byte (Hex) | Mệnh giá |
| ---------- | -------- |
| 0x40       | 5,000    |
| 0x41       | 10,000   |
| 0x42       | 20,000   |
| 0x43       | 50,000   |
| 0x44       | 100,000  |
| 0x45       | 200,000  |
| 0x46       | 500,000  |

> ⚠️ Byte mệnh giá **chỉ là nhận dạng tờ tiền**, KHÔNG có nghĩa là tiền đã được chấp nhận.

---

## Quy tắc cộng tiền (RẤT QUAN TRỌNG)

- Khi nhận byte mệnh giá (`0x40` – `0x46`)
  - ❌ **KHÔNG cộng tiền**
  - ✅ Chỉ lưu tạm `currentNoteValue`

- Chỉ khi nhận:
  - `0x10` → **ACCEPTED**
    - ✅ cộng `currentNoteValue` vào `totalAmount`
  - `0x11` → **REJECTED**
    - ❌ bỏ giá trị vừa nhận

---

## Pseudo flow chuẩn

```text
[IDLE]
  ↓
Receive denomination byte (0x4X)
  → store currentNoteValue
  ↓
Wait for result
  ├─ 0x10 (ACCEPTED) → total += currentNoteValue
  └─ 0x11 (REJECTED) → discard

```

_End of document_
