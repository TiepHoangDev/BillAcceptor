## https://topmaygapthu.vn/dau-doc-tien-top-tb74

Ok, tôi sẽ **viết đúng kiểu “spec kỹ thuật + mô tả hành vi” để bạn ném thẳng cho AI/codegen** viết app C# Windows.
Không giải thích lan man nữa.

---

# 📌 MÔ TẢ CHUẨN ĐỂ AI CODE C#

**Thiết bị**: Bill Acceptor TB74
**Giao tiếp**: RS232 (106U)
**Mục tiêu app**:

- Đếm **tổng tiền**
- Ghi **log chi tiết từng tờ**
- Chạy **Windows PC**

---

## 1️⃣ Tổng quan hệ thống

- TB74 là máy nhận tiền giấy
- Máy **tự nhận dạng mệnh giá** bằng cảm biến nội bộ (quang + từ)
- Sau khi nhận thành công, TB74 **gửi dữ liệu mệnh giá qua RS232**
- PC (C# app) **chỉ đọc dữ liệu**, không điều khiển phần cứng

---

## 2️⃣ Cấu hình phần cứng (điều kiện tiên quyết)

- DIP Switch SETTING 2:

  - `RS232 Protocol = ON`
  - `Pulse Protocol = OFF`

- Reset máy sau khi gạt DIP
- Kết nối qua USB → RS232 (COM port)

---

## 3️⃣ Thông số Serial Port (FIX CỨNG)

```text
Baud rate : 9600
Data bits : 8
Parity    : None
Stop bits: 1
Flow ctrl: None
```

- Dữ liệu truyền là **binary (byte)**, KHÔNG phải text

---

## 4️⃣ Nguyên tắc giao tiếp RS232 của TB74

- Mỗi lần **nhận thành công 1 tờ tiền**
- TB74 gửi **1 frame dữ liệu**
- App C# phải:

  - Đọc **byte stream**
  - Tách frame
  - Decode mệnh giá
  - Cộng vào tổng

---

## 5️⃣ Cấu trúc frame (mô hình hóa cho AI)

> ⚠ Frame là **nhị phân**, không dùng ReadLine()

### Dạng tổng quát

```
[STX] [DATA] [ETX]
```

| Byte | Giá trị |
| ---- | ------- |
| STX  | 0x02    |
| ETX  | 0x03    |

---

## 6️⃣ Ý nghĩa DATA (chuẩn hoá để code)

DATA là **ASCII số**, biểu diễn mệnh giá logic do firmware TB74 gửi.

Ví dụ mapping (VND):

| DATA ASCII | Mệnh giá |
| ---------- | -------- |
| "05"       | 5,000    |
| "10"       | 10,000   |
| "20"       | 20,000   |
| "50"       | 50,000   |
| "100"      | 100,000  |
| "200"      | 200,000  |
| "500"      | 500,000  |

> AI cần hiểu: DATA đọc ra là ASCII, nhưng frame là byte.

---

## 7️⃣ Luồng xử lý chuẩn trong app

```
SerialPort open
↓
Nhận byte stream
↓
Buffer byte
↓
Tìm STX (0x02)
↓
Tìm ETX (0x03)
↓
Cắt frame
↓
Decode DATA → mệnh giá
↓
Cộng tổng
↓
Log
```

---

## 8️⃣ Yêu cầu logic C# (AI cần implement)

### Biến trạng thái

```text
totalMoney : int
billHistory : list
```

### Mỗi bill hợp lệ:

- Tăng `totalMoney`
- Ghi log gồm:

  - Thời gian
  - Mệnh giá
  - Tổng tiền sau khi cộng

---

## 9️⃣ Log format (chuẩn hoá)

```text
YYYY-MM-DD HH:mm:ss | +100000 | TOTAL=350000
```

---

## 🔟 Điều C# KHÔNG ĐƯỢC làm

- ❌ Không gửi lệnh điều khiển TB74
- ❌ Không điều khiển accept / reject
- ❌ Không suy đoán mệnh giá
- ❌ Không parse theo text line

---

## 1️⃣1️⃣ Điều kiện lỗi cần xử lý

- Frame thiếu STX hoặc ETX → bỏ
- DATA không map được → ignore
- Serial disconnect → auto retry

---

## 1️⃣2️⃣ Kết luận cho AI

> “TB74 acts as a passive bill validator.
> It autonomously recognizes bill denominations and sends one RS232 binary frame per accepted bill.
> The C# application only listens, parses frames, decodes denominations, updates total money, and logs events.”

---
