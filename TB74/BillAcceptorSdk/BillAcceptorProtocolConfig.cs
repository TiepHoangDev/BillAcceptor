namespace BillAcceptorSdk;

public class BillAcceptorProtocolConfig
{
    public byte PowerUpByte { get; set; } = 0x80;
    public byte PowerUpResponseByte { get; set; } = 0x8F;
    public byte AckByte { get; set; } = 0x02;
    public byte EnableByte { get; set; } = 0x3E;
    public byte DisableByte { get; set; } = 0x5E;
    public byte EscrowStartByte { get; set; } = 0x81;
    public byte RejectByte { get; set; } = 0x0F;
    public byte StackedByte { get; set; } = 0x10;
    public byte RejectedByte { get; set; } = 0x11;
    public byte ResetByte { get; set; } = 0x30;

    public Dictionary<byte, long> BillTypeMapping { get; set; } = new Dictionary<byte, long>
    {
        { 0x40, 5000 },
        { 0x41, 10000 },
        { 0x42, 20000 },
        { 0x43, 50000 },
        { 0x44, 100000 },
        { 0x45, 500000 }
    };

    public static BillAcceptorProtocolConfig Default => new BillAcceptorProtocolConfig();
}
