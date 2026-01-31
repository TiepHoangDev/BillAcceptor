namespace BillAcceptorSdk;

public class BillAcceptorProtocolConfig
{
    //POWER
    public byte PowerUpByte { get; set; } = 0x80;
    public byte PowerUpResponseByte { get; set; } = 0x8F;
    public byte AckByte { get; set; } = 0x02;

    //BILL ACCEPTOR
    public byte EscrowStartByte { get; set; } = 0x81;
    public byte EscrowSecondByte { get; set; } = 0x8f;
    public byte AcceptByte { get; set; } = 0x02;
    public byte RejectByte { get; set; } = 0x0F;
    public byte StackedByte { get; set; } = 0x10;
    public byte RejectedByte { get; set; } = 0x11;

    // Enable / Disable / Reset
    public byte EnableByte { get; set; } = 0x3E;
    public byte DisableByte { get; set; } = 0x5E;
    public byte ResetByte { get; set; } = 0x30;

    // Power Commands
    public byte[] PowerOnCommand { get; set; } = [85, 86, 0, 0, 0, 1, 1, 173];
    public byte[] PowerOffCommand { get; set; } = [85, 86, 0, 0, 0, 1, 2, 174];

    public Dictionary<byte, long> BillTypeMapping { get; set; } = new Dictionary<byte, long>
    {
        { 0x40, 10000 },
        { 0x41, 20000 },
        { 0x42, 50000 },
        { 0x43, 100000 },
        { 0x44, 200000 },
    };

    public static BillAcceptorProtocolConfig Default => new BillAcceptorProtocolConfig();

}
