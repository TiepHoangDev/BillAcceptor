public static void ConnectComPortPowerRS232CH2()
{
try
{
if (string.IsNullOrEmpty(mdlPowerControl.selPortPowerRS232))
{
mdlFileIO.FileAppendShare(mdlMain.dslrBooth_logs, DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : ConnectComPortPower - COM Port Power not set");
}
else
{
if (mdlPowerControl.SerialPortPowerRS232.IsOpen)
{
mdlPowerControl.SerialPortPowerRS232.Close();
}
mdlPowerControl.SerialPortPowerRS232.PortName = mdlPowerControl.selPortPowerRS232;
mdlPowerControl.SerialPortPowerRS232.BaudRate = 9600;
mdlPowerControl.SerialPortPowerRS232.DataBits = 8;
mdlPowerControl.SerialPortPowerRS232.StopBits = StopBits.One;
mdlPowerControl.SerialPortPowerRS232.Handshake = Handshake.None;
mdlPowerControl.SerialPortPowerRS232.Parity = Parity.None;
mdlPowerControl.SerialPortPowerRS232.Open();
}
}
catch (Exception ex)
{
mdlFileIO.FileAppendShare(mdlMain.dslrBooth_logs, DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : Error can't connect device - " + ex.Message);
}
}

PowerONBillAcceptor -> mdlPowerControl.SerialPortPowerRS232.Write(mdlPowerControl.CommandPowerOnRS232CH21, 0, mdlPowerControl.CommandPowerOnRS232CH21.Length);
await mdlFileIO.FileAppendShareAsync(mdlMain.dslrBooth_logs, strDT + " : PowerON - OK");
public static byte[] CommandPowerOnRS232CH21 = new byte[]
{
85,
86,
0,
0,
0,
1,
1,
173
};

this.SerialPortBillAcceptor.PortName = mdlBillEnable.selPortBillAcceptor;
this.SerialPortBillAcceptor.BaudRate = 9600;
this.SerialPortBillAcceptor.DataBits = 8;
this.SerialPortBillAcceptor.StopBits = StopBits.One;
this.SerialPortBillAcceptor.Handshake = Handshake.None;
this.SerialPortBillAcceptor.Parity = Parity.Even;
this.SerialPortBillAcceptor.Encoding = Encoding.UTF8;
this.SerialPortBillAcceptor.Open();

this.SerialPortBillAcceptor.Read(ByteReceived, 0, 1);

private void handleBillAcceptorByteTB4(byte ByteReceived)
{
this.i = 180L;
try
{
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : ByteReceived - {1:x2}", DateAndTime.Now, ByteReceived));
if (!this.touchEnabled)
{
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : Form3_4-exit - can't handle bill acceptor", DateAndTime.Now));
}
else if (ByteReceived <= 41)
{
if (ByteReceived != 16)
{
if (ByteReceived != 39)
{
if (ByteReceived == 41)
{
this.firstByteError = 41;
this.isWaitingForErrorACK = true;
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : cash_return - invalid banknote code = {1:x2}", DateAndTime.Now, ByteReceived));
this.DrawNotify("The banknote is not correct. Please try inserting it again.", false);
}
}
else
{
if (this.billAccepting)
{
this.billAccepting = false;
this.BillReceive(this.CurrentReceiveBill);
}
mdlLineNotify.SendLineNotifyAsyncJai(mdlCustomerInfo.booth_name + "\r\ncash error code H27" + string.Format("amount: {0}", this.CurrentReceiveBill));
}
}
else
{
this.billAccepting = false;
this.BillReceive(this.CurrentReceiveBill);
}
}
else if (ByteReceived <= 70)
{
if (ByteReceived != 47)
{
switch (ByteReceived)
{
case 64:
this.CurrentReceiveBill = 5000;
this.BillReject(this.CurrentReceiveBill);
this.DrawNotify("The system does not accept 5000 VND banknotes.", false);
break;
case 65:
this.CurrentReceiveBill = 10000;
if (mdlBillEnable.BillListEnable[0])
{
this.BillAccept(this.CurrentReceiveBill);
}
else
{
this.BillReject(this.CurrentReceiveBill);
}
break;
case 66:
this.CurrentReceiveBill = 20000;
if (mdlBillEnable.BillListEnable[1])
{
this.BillAccept(this.CurrentReceiveBill);
}
else
{
this.BillReject(this.CurrentReceiveBill);
}
break;
case 67:
this.CurrentReceiveBill = 50000;
if (mdlBillEnable.BillListEnable[2])
{
this.BillAccept(this.CurrentReceiveBill);
}
else
{
this.BillReject(this.CurrentReceiveBill);
}
break;
case 68:
this.CurrentReceiveBill = 100000;
if (mdlBillEnable.BillListEnable[3])
{
this.BillAccept(this.CurrentReceiveBill);
}
else
{
this.BillReject(this.CurrentReceiveBill);
}
break;
case 69:
this.CurrentReceiveBill = 200000;
if (mdlBillEnable.BillListEnable[4])
{
this.BillAccept(this.CurrentReceiveBill);
}
else
{
this.BillReject(this.CurrentReceiveBill);
}
break;
case 70:
this.CurrentReceiveBill = 500000;
if (mdlBillEnable.BillListEnable[5])
{
this.BillAccept(this.CurrentReceiveBill);
}
else
{
this.BillReject(this.CurrentReceiveBill);
}
break;
}
}
else
{
if (this.isWaitingForErrorACK)
{
this.isWaitingForErrorACK = false;
byte b = this.firstByteError;
if (b == 41 && this.billAccepting)
{
this.billAccepting = false;
this.BillToggle();
}
}
this.firstByteError = 0;
}
}
else if (ByteReceived != 128)
{
if (ByteReceived == 143)
{
if (this.isWaitingForSuccessACK)
{
this.isWaitingForSuccessACK = false;
byte b2 = this.firstByteSuccess;
if (b2 != 128)
{
if (b2 != 129)
{
}
}
else
{
this.BillEnable();
}
}
this.firstByteSuccess = 0;
}
}
else
{
this.firstByteSuccess = 128;
this.isWaitingForSuccessACK = true;
}
}
catch (Exception ex)
{
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : handleBillAcceptorByte - Error: {1}", DateAndTime.Now, ex.Message));
}
}

private void BillAccept(int CurrentReceiveBill)
{
try
{
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : BillAccept - {1}", DateAndTime.Now, CurrentReceiveBill));
this.billAccepting = true;
object obj = this.lockSerialPortBillAcceptor;
ObjectFlowControl.CheckForSyncLockOnValueType(obj);
lock (obj)
{
this.SerialPortBillAcceptor.Write(this.CommandBillAccept, 0, 1);
}
}
catch (Exception ex)
{
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : BillAccept - Error: {1}", DateAndTime.Now, ex.Message));
}
}

private void BillReject(int CurrentReceiveBill)
{
try
{
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : BillReject - {1}", DateAndTime.Now, CurrentReceiveBill));
object obj = this.lockSerialPortBillAcceptor;
ObjectFlowControl.CheckForSyncLockOnValueType(obj);
lock (obj)
{
this.SerialPortBillAcceptor.Write(this.CommandBillReject, 0, 1);
}
}
catch (Exception ex)
{
mdlFileIO.FileAppendShare(string.Format("{0:yyyy-MM-dd HH:mm:ss} : BillReject - Error: {1}", DateAndTime.Now, ex.Message));
}
}

II. Log

2026-01-29 11:55:28 : PowerON - OK
2026-01-29 11:55:28 : PhotoVideo-Disable
2026-01-29 11:55:28 : dslrBooth Mode : i = 0
2026-01-29 11:55:28 : PrinterName1 =
2026-01-29 11:55:29 : CheckPrinter1 - DS-RX1
2026-01-29 11:55:29 : PrinterStatus = PRINTER_STATUS_READY
2026-01-29 11:55:29 : CheckPrinter1 - DS-RX1, isPrinterReady: True
2026-01-29 11:55:29 : CheckPrinter2 - DS-RX1
2026-01-29 11:55:29 : PrinterStatus = PRINTER_STATUS_READY
2026-01-29 11:55:29 : CheckPrinter2 - DS-RX1, isPrinterReady: True
2026-01-29 11:55:29 : ReportComputerInfo - Start
2026-01-29 11:55:36 : ReportComputerInfo - OK, n=1
2026-01-29 11:55:36 : checkProgramUpdate - Start
2026-01-29 11:55:36 : checkProgramUpdate - OK, updateType: 0
2026-01-29 11:55:36 : displayScale = 100%
2026-01-29 11:55:36 : Screen Size W: 1920, H: 1080
2026-01-29 11:55:36 : Checking Canon camera (Attempt 1)
2026-01-29 11:55:36 : GetCanonCameraName - Start
2026-01-29 11:55:36 : EdsInitializeSDK - err = 0
2026-01-29 11:55:36 : EdsGetCameraList - err = 0
2026-01-29 11:55:36 : EdsGetChildCount - count = 1, err = 0
2026-01-29 11:55:36 : EdsGetChildAtIndex - err = 0
2026-01-29 11:55:36 : EdsGetDeviceInfo - err = 0
2026-01-29 11:55:36 : Found Camera: Canon EOS R100
2026-01-29 11:55:36 : Released camera
2026-01-29 11:55:36 : Released cameraList
2026-01-29 11:55:36 : EdsTerminateSDK
2026-01-29 11:55:36 : Camera = Canon EOS R100
2026-01-29 11:55:36 : last sync: 29/01/2026 11:11:37
2026-01-29 11:55:36 : WebSocket try connecting on Form1_Load
2026-01-29 11:55:37 : Connected to WebSocket server.
2026-01-29 11:55:37 : WebSocket state changed -> Open
2026-01-29 11:55:48 : Next : i = 30, print_qty : 1, FrameSize: Frame2x6
2026-01-29 11:55:50 : cash machine : i = 118, print_qty : 1
2026-01-29 11:55:51 : PowerON - OK
2026-01-29 11:55:51 : ConnectBillAcceptor - connecting
2026-01-29 11:55:51 : ConnectBillAcceptor - connected
2026-01-29 11:55:52 : ByteReceived - 80
2026-01-29 11:55:52 : ByteReceived - 8f
2026-01-29 11:55:52 : BillEnable
2026-01-29 11:56:13 : ByteReceived - 81
2026-01-29 11:56:13 : ByteReceived - 8f
2026-01-29 11:56:13 : ByteReceived - 42
2026-01-29 11:56:13 : BillAccept - 50000
2026-01-29 11:56:14 : ByteReceived - 10
2026-01-29 11:56:14 : Create cash_id_local: 2135, cashUUID: 6c0109be88544104ab00880753cf0c34
2026-01-29 11:56:14 : Create cash_receive_id_local: 4330, cashReceiveUUID: 1ba0ae1b4f214000a38960288b85ef68, cash_id_local: 2135
2026-01-29 11:56:14 : bill = 50000, total_received - 50000
2026-01-29 11:56:14 : Create cash_id-0
2026-01-29 11:56:14 : CashCreateIDAsync - {
"booth_id": 324,
"payment_type_id": "2",
"print_qty": 1,
"payment_price": 70000.0,
"status": 0,
"ticket_discount_id": "NULL",
"cash_uuid": "6c0109be88544104ab00880753cf0c34",
"create_time": "2026-01-29 11:56:14",
"print_mode_id": 0,
"transaction_uuid": "CWZcqEk"
}
2026-01-29 11:56:14 : CashCreate : {"status":200,"message":"ok", "transaction_id":"2317938", "source_id":"1299577", "id":"1299577"}
2026-01-29 11:56:14 : cash_id : 1299577, transaction_id : 2317938 - created, n=1
2026-01-29 11:56:14 : Create cash_receive_id
2026-01-29 11:56:14 : cash_receive_id : 3337329 - created, n=1
2026-01-29 11:56:18 : ByteReceived - 81
2026-01-29 11:56:18 : ByteReceived - 8f
2026-01-29 11:56:18 : ByteReceived - 41
2026-01-29 11:56:18 : BillAccept - 20000
2026-01-29 11:56:18 : ByteReceived - 10
2026-01-29 11:56:18 : Create cash_receive_id_local: 4331, cashReceiveUUID: 96d09556dffe470e89b54dac8053e6e8, cash_id_local: 2135
2026-01-29 11:56:18 : bill = 20000, total_received - 70000
2026-01-29 11:56:18 : BillAcceptorDisable
2026-01-29 11:56:18 : Create cash_receive_id
2026-01-29 11:56:18 : BillDisable
2026-01-29 11:56:18 : start_session_cash-1
2026-01-29 11:56:18 : cash : 10000x0, 20000x1, 50000x1, 100000x0, 200000x0, 500000x0
2026-01-29 11:56:18 : cash_receive_id : 3337330 - created, n=1
2026-01-29 11:56:18 : PowerON - OK
2026-01-29 11:56:18 : KillProcess - CameraControl : not found
2026-01-29 11:56:18 : EventSelectByFrame = True, EventSelected = None, EventSelectedPrevious = None, FrameSizeSelected = Frame2x6, FrameSizeSelectedPrevious = None
2026-01-29 11:56:18 : KillProcess - dslrBooth : not found
2026-01-29 11:56:18 : ByteReceived - 5e
2026-01-29 11:56:18 : Form3_4-exit - can't handle bill acceptor
2026-01-29 11:56:19 : PowerOFF - OK

III. Data từ hecules hex

Lan 1: 70k
COM52
3<{00}{00}{00}{02}{01}r3<{00}{00}{00}{02}{01}r3<{00}{00}{00}{01}{01}q3<{00}{00}{00}{02}{01}r3<{00}{00}{00}{01}{02}r

COM62
€€@{10}@{10}B{10}^

lan 2: 70k (50k + 20k)

COM52
{33}{3C}{00}{00}{00}{02}{01}{72}{33}{3C}{00}{00}{00}{02}{01}{72}{33}{3C}{00}{00}{00}{01}{01}{71}{33}{3C}{00}{00}{00}{02}{01}{72}{33}{3C}{00}{00}{00}{01}{02}{72}{33}{3C}{00}{00}{00}{02}{01}{72}{33}{3C}{00}{00}{00}{02}{01}{72}

COM62
{80}{8F}{81}{8F}{42}{10}{81}{8F}{41}{10}{5E}
