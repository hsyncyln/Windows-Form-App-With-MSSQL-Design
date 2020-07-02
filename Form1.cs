using Microsoft.SqlServer.Management.Smo;
using System;
using System.Windows.Forms;
using Microsoft.Build.Evaluation;
using System.Reflection;

namespace NorthWnd2
{
    public partial class Form1 : Form
    {
        Project proje = new Microsoft.Build.Evaluation.Project(@"C:\Users\samet\source\repos\NorthWnd2\NorthWnd2.csproj");
        public Form1()
        {
            InitializeComponent();
        }
        private readonly string[] SqlServerTypes = { "bigint", "binary", "bit", "char", "date", "datetime", "datetime2", "datetimeoffset", "decimal", "filestream",
            "float", "geography", "geometry", "hierarchyid", "image", "int", "money", "nchar", "ntext", "numeric", "nvarchar", "real", "rowversion", "smalldatetime",
            "smallint", "smallmoney", "sql_variant", "text", "time", "timestamp", "tinyint", "uniqueidentifier", "varbinary", "varchar", "xml" };

        private readonly Type[] CSharpTypes = { typeof(long), typeof(byte[]), typeof(bool), typeof(char), typeof(DateTime), typeof(DateTime), typeof(DateTime),
            typeof(DateTimeOffset), typeof(decimal), typeof(byte[]), typeof(double), typeof(Microsoft.SqlServer.Types.SqlGeography),
            typeof(Microsoft.SqlServer.Types.SqlGeometry), typeof(Microsoft.SqlServer.Types.SqlHierarchyId), typeof(byte[]), typeof(int),
            typeof(decimal),typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(Single), typeof(byte[]), typeof(DateTime),
            typeof(short), typeof(decimal), typeof(object), typeof(string), typeof(TimeSpan), typeof(byte[]), typeof(byte), typeof(Guid), typeof(byte[]),
            typeof(string), typeof(string) };

        public Type ConvertSqlServerFormatToCSharp(string typeName)
        {
            var index = Array.IndexOf(SqlServerTypes, typeName);

            if (index > -1) return CSharpTypes[index];
            else return typeof(object);        
        }

        public string ConvertCSharpFormatToSqlServer(string typeName)
        {
            var index = Array.IndexOf(CSharpTypes, typeName);

            if (index > -1) return SqlServerTypes[index];
            else return null;
        }
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            treeViewDatabase.Nodes.Clear();

            Server svr = new Server(@".\MSSQLServer01");

            TreeNode mainNode = new TreeNode(svr.GetSqlServerVersionName());
            mainNode.ImageIndex = 0;
            treeViewDatabase.Nodes.Add(mainNode);
            
            foreach(Database db in svr.Databases)
            {
                TreeNode node = new TreeNode(db.Name);
                node.ImageIndex = 1;
                node.Tag = db;
                mainNode.Nodes.Add(node);
            }
        }

        private void TreeViewDatabase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if(e.Node.Tag is Database)
            {
                if (e.Node.Checked == false)
                {
                    foreach (Table tbl in (e.Node.Tag as Database).Tables)
                    {
                        TreeNode node = new TreeNode(tbl.Name);
                        node.ImageIndex = 2;
                        node.Tag = tbl;
                        e.Node.Nodes.Add(node);
                    }
                }
                else e.Node.ImageIndex = 1;
                
            }
            if (e.Node.Tag is Table)
            {
                if (e.Node.Checked == false)
                {
                    foreach (Column col in (e.Node.Tag as Table).Columns)
                    {
                        TreeNode node = new TreeNode(col.Name);
                        node.Tag = col;
                        e.Node.Nodes.Add(node);
                        node.ImageIndex = 3;
                        if (col.InPrimaryKey) node.ImageIndex = 4;
                        else if (col.IsForeignKey) node.ImageIndex = 5;
                    }
                }
                else e.Node.ImageIndex = 2;
             
            }


        }
        private void GenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (treeViewDatabase.SelectedNode.Tag is Table)
            {
                Table table = (Table)treeViewDatabase.SelectedNode.Tag;
                Assembly asm = Assembly.GetExecutingAssembly();
                Type[] types = asm.GetTypes();
                bool result = false;

                foreach(Type type in types)
                {
                    if(type.IsClass && type.Name != table.Name)
                    {
                        result = true;
                    }
                    else
                    {
                        MessageBox.Show("Aynı isimli class bulunmakta.");
                        result = false;
                        break;
                    }
                }
                if (result == true)
                {
                    GenerateClass sample = new GenerateClass(table.Name);

                    foreach(Column col in table.Columns)
                    {
                        sample.AddProperties(col.Name, ConvertSqlServerFormatToCSharp(col.DataType.Name));
                    }
                    sample.GenerateCSharpCode(table.Name,proje);
                    MessageBox.Show("Başarılı bir şekilde oluşturuldu.");
                }
            }
            else
            {
                MessageBox.Show("Tablo değilse class olusturulamaz.");
            }
          
        }
    }
}