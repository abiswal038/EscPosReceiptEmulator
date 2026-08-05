using ReceiptPrinterEmulator.Emulator;

namespace ReceiptPrinterEmulator.EscPos.Commands.ESC;

/// <summary>
/// Recognize ESC V, which may appear in raw ESC/POS streams.
/// This emulator currently ignores the command rather than failing.
/// </summary>
public class SelectPrintDirectionCommand : BaseCommand
{
    public override string Prefix => EscPosInterpreter.ESC + "V";
    public override bool HasArgs => true;

    private byte _n;

    public override void Reset()
    {
        _n = 0;
    }

    public override bool InterpretNextChar(char c)
    {
        _n = (byte)c;
        return false;
    }

    public override bool InterpretNextByte(byte b)
    {
        _n = b;
        return false;
    }

    public override void Execute(ReceiptPrinter printer, string? args)
    {
        // No-op for unsupported ESC V command.
    }
}
