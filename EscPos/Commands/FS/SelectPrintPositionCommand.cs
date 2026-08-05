using ReceiptPrinterEmulator.Emulator;

namespace ReceiptPrinterEmulator.EscPos.Commands.FS;

/// <summary>
/// Recognize the FS . command so unsupported binary streams can continue.
/// The command is currently treated as a no-op in the emulator.
/// </summary>
public class SelectPrintPositionCommand : BaseCommandNoArgs
{
    public override string Prefix => EscPosInterpreter.FS + ".";

    public override void Execute(ReceiptPrinter printer, string? args)
    {
        // FS . is an unsupported/ignored positioning command in this emulator.
    }
}
