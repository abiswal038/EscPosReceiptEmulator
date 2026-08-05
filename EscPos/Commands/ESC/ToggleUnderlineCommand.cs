using ReceiptPrinterEmulator.Emulator;
using ReceiptPrinterEmulator.Emulator.Enums;

namespace ReceiptPrinterEmulator.EscPos.Commands.ESC;

/// <summary>
/// Turn underline mode on/off
/// https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=24
/// </summary>
public class ToggleUnderlineCommand : BaseCommand
{
    public override string Prefix => EscPosInterpreter.ESC + "-";
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
        return false;
    }

    public override void Execute(ReceiptPrinter printer, string? args)
    {
        int n = _n;
        if (!string.IsNullOrEmpty(args)) n = args[0];

        if (n is 0 or 48)
            printer.SelectUnderlineMode(UnderlineMode.Off);
        else if (n is 1 or 49)
            printer.SelectUnderlineMode(UnderlineMode.OnOneDot);
        else if (n is 2 or 50)
            printer.SelectUnderlineMode(UnderlineMode.OnTwoDots);
    }

    public override void Execute(ReceiptPrinter printer, byte[]? args)
    {
        var n = _n;
        if (args != null && args.Length > 0) n = args[0];

        if (n == 0 || n == 48)
            printer.SelectUnderlineMode(UnderlineMode.Off);
        else if (n == 1 || n == 49)
            printer.SelectUnderlineMode(UnderlineMode.OnOneDot);
        else if (n == 2 || n == 50)
            printer.SelectUnderlineMode(UnderlineMode.OnTwoDots);
    }
}
