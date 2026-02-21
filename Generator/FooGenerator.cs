using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.IO;

namespace Generator
{
    [Generator]
    public class FooGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            //var featureFiles = context.AdditionalFiles.Where(file => file.Path.EndsWith(".feature"));

            //foreach (var featureFile in featureFiles)
            //{
            //    var fileName = System.IO.Path.GetFileNameWithoutExtension(featureFile.Path);

            //    var sourceText = File.ReadAllText($"{featureFile.Path}.cs").Replace("BStack", "Foo");

            //    context.AddSource($"{fileName}.g.cs", sourceText);
            //}

            var comp = context.Compilation;

            foreach (var tree in comp.SyntaxTrees)
            {
                var path = tree.FilePath;

                if (path.EndsWith(".feature.cs"))
                {
                    var st = tree.GetText(context.CancellationToken);

                    var sourceText = st.ToString().Replace("BStack", "Foo");

                    var fileName = Path.GetFileNameWithoutExtension(tree.FilePath);
                    var newFileName = fileName.Replace("Sample", "Foo");

                    context.AddSource($"{newFileName}.g.cs", sourceText);
                }
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
        }
    }
}
