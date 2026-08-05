using ReceiptPrinterEmulator.Emulator;

namespace ReceiptPrinterEmulator.EscPos.Commands.ESC;

/// <summary>
/// Turn emphasized mode on/off
/// https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=25
/// </summary>
public class ToggleEmphasizeCommand : BaseCommand
{
    public override string Prefix => EscPosInterpreter.ESC + "E";
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

    // New byte-based interpreter
    public override bool InterpretNextByte(byte b)
    {
        _n = b;
        return false; // single-arg command
    }

    public override void Execute(ReceiptPrinter printer, string? args)
    {
        byte n = _n;
        if (!string.IsNullOrEmpty(args)) n = (byte)args[0];

        if (n == 0)
            printer.SelectEmphasizeMode(false);
        else if (n == 1)
            printer.SelectEmphasizeMode(true);
    }

    public override void Execute(ReceiptPrinter printer, byte[]? args)
    {
        byte n = _n;
        if (args != null && args.Length > 0) n = args[0];

        printer.SelectEmphasizeMode(n != 0);
    }
}
