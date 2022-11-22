using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilderApp
{
    [Table ("PCBuild")]
    public class PCBuild
    {
        [NotNull, PrimaryKey, AutoIncrement, Unique, Column("PCBuildID")]
        public int PCBuildID { get; set; }
        [NotNull]
        public string PCCpu { get; set; }
        [NotNull]
        public string PCCpuCooler { get; set; }
        [NotNull]
        public string PCGpu { get; set; }
        [NotNull]
        public string PCMotherboard { get; set; }
        [NotNull]
        public string PCRam { get; set; }
        [NotNull]
        public string PCStorage { get; set; }
        [NotNull]
        public string PCPsu { get; set; }
        [NotNull]
        public string PCCase { get; set; }
    }
}
