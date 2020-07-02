using Microsoft.Build.Evaluation;
using Microsoft.Build.Utilities;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthWnd2
{
    
    class GenerateClass
    {
      // Project proje = new Microsoft.Build.Evaluation.Project(@"C:\Users\samet\source\repos\NorthWnd2\NorthWnd2.csproj");
        Assembly asm = Assembly.GetExecutingAssembly();
        CodeTypeDeclaration Class;
        CodeCompileUnit compileUnit;

        public GenerateClass(string className)
        {
            CodeNamespace sample = new CodeNamespace(asm.GetName().Name);
            sample.Imports.Add(new CodeNamespaceImport("System"));
            Class = new CodeTypeDeclaration(className);
            Class.IsClass = true;
            Class.TypeAttributes = TypeAttributes.Public;
            sample.Types.Add(Class);
            compileUnit = new CodeCompileUnit();
            compileUnit.Namespaces.Add(sample);
        }

        public void AddProperties(string propName,Type type)
        {
            CodeMemberProperty property = new CodeMemberProperty();
            property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            property.Name = propName;
            property.HasGet = true;
            property.HasSet = true;
            property.GetStatements.Add(new CodeMethodReturnStatement(
                 new CodeFieldReferenceExpression(
                 new CodeThisReferenceExpression(), propName)));
            property.Type = new CodeTypeReference(type);
            Class.Members.Add(property);
        }
        public void GenerateCSharpCode(string fileName,Project proje)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";

            
            using (StreamWriter source = new StreamWriter(string.Format(@"C:\Users\samet\source\repos\NorthWnd2\{0}.cs", fileName)))
            {
                provider.GenerateCodeFromCompileUnit(compileUnit, source, options);
            }
            
            proje.AddItem("Compile", fileName+".cs");
            proje.Save();
        }
    }
}
