public interface ICompanentVisitor {
    void Visit(UICompanentConfig companent);
    void Visit(ModelViewConfig selectorView);
    void Visit(AssemblyStageViewConfig assemblyStageView);
}