namespace BillAcceptorSdk;

public class BillAcceptorHandlerInput
{
    public BillAcceptorConfig Config { get; set; } = null!;
    public SerialPortTransport BATranport { get; set; } = null!;
}

