public interface IDialogTypeVisitor {
    void Visit(Dialog dialog);
    void Visit(DesktopDialog desktop);
    void Visit(PlanesListDialog transactions);
    void Visit(AssemblyDialog category);
    void Visit(AboutDialog aboutDialog);
}
