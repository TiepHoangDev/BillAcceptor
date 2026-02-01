
namespace BillAcceptorSdk.Handlers;

public class GetStatusBillAcceptorHandler : BaseBillAcceptorHandler
{
    static Dictionary<byte, string> billAcceptorStatus = new Dictionary<byte, string>
    {
        { 0x20, "Motor Failure" },          // 20H (32)
        { 0x21, "Checksum Error" },         // 21H (33)
        { 0x22, "Bill Jam" },               // 22H (34)
        { 0x23, "Bill Remove" },            // 23H (35)
        { 0x24, "Stacker Open" },           // 24H (36)
        { 0x25, "Sensor Problem" },         // 25H (37)
        { 0x27, "Bill Fish" },              // 27H (39)
        { 0x28, "Stacker Problem" },         // 28H (40)
        { 0x29, "Bill Reject" },             // 29H (41)
        { 0x2A, "Invalid Command" },         // 2AH (42)

        // 2BH-2DH not defined in table

        { 0x2E, "Reserved" },                // 2EH (46)
        { 0x2F, "Response when Error Status is Exclusion" }, // 2FH (47)

        { 0x3E, "Bill Acceptor Enable Status" },  // 3EH (62)
        { 0x5E, "Bill Acceptor Inhibit Status" }  // 5EH (94)
    };

    public GetStatusBillAcceptorHandler(BillAcceptorHandlerInput billAcceptorHandlerInput) : base(billAcceptorHandlerInput)
    {
    }

    public override bool CanHandle(byte data)
    {
        return billAcceptorStatus.ContainsKey(data);
    }

    public override Task HandleResponse(byte data)
    {
        RaiseSuccess();
        return Task.CompletedTask;
    }

    public override async Task SendAsync()
    {
        await BATranport.WriteAsync(0x0C);
    }
}

