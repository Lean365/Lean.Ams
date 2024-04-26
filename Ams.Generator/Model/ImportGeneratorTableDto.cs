using System.Collections.Generic;

namespace Ams.Generator.Model
{
    public class ImportGeneratorTableDto
    {
        public int FrontTpl { get; set; }
        public string DbName { get; set; }
        public List<GeneratorTables> Tables { get; set; }
    }

    public class GeneratorTables
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}