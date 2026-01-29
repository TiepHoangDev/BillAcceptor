namespace BillAcceptorSdk;

public class BillAcceptorHandlerInput
{
    public required BillAcceptorConfig Config { get; set; }
    public required SerialPortTransport BATranport { get; set; }
}

