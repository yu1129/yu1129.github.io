using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static practice_02.ApidNewEntity;
using System.Xml;
using Newtonsoft.Json;

namespace practice_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var processMap = new List<ProcessData> {
                new ProcessData { Apid = "DIY_MA_MESHOLD", ProcessId = "apid1028_Process01", Seq = 1 },
                new ProcessData { Apid = "DIY_MA_MESHOLD", ProcessId = "1111_Process01", Seq = 2 },
                new ProcessData { Apid = "DIY_MA_MESHOLD", ProcessId = "", Seq = 1 },
                new ProcessData { Apid = "DIY_MA_MESHOLD", ProcessId = "", Seq = 2 },
                new ProcessData { Apid = "DIY_MA_MESHOLD", ProcessId = "", Seq = 3 },
            };
            var step = new List<StepData>
            {
                new StepData { ProcessId = "apid1028_Process01", ProcessName = "apid1028_Process01_Name", Description = "apid1028_Process01_Desc", TemplateId = "2" },
                new StepData { ProcessId = "1111_Process01", ProcessName = "1111_Process01_Name", Description = "1111_Process01_Desc", TemplateId = "2" },
            };
            var template = new List<TemplateData>
            {
                new TemplateData{ TemplateId = "2", TemplateName = "??" },
            };
            var filter = new List<FilterData>
            {
                new FilterData{ Apid = "DIY_MA_MESHOLD", ControlType = 1, ControlIdDesc = "MO", Seq = 1 },
                new FilterData{ Apid = "DIY_MA_MESHOLD", ControlType = 5, ControlIdDesc = "USN", Seq = 2 },
                new FilterData{ Apid = "DIY_MA_MESHOLD", ControlType = 5, ControlIdDesc = "BIN", Seq = 3 },
            };

            var result = processMap.GroupBy(pm => pm.Apid).Select(pm =>
                        new ApidNewEntity
                        {
                            Apid = pm.Key,
                            Steps = step.Where(p => pm.Select(item => item.ProcessId).Contains(p.ProcessId)).Select(p => new ApidNewEntity.StepInfo
                            {
                                StepId = p.ProcessId,
                                StepName = p.ProcessName,
                                Descripion = p.Description,
                                Seq = pm.Where(item => item.ProcessId == p.ProcessId).Select(item => item.Seq).Distinct().First(),
                            }).ToList(),
                            TemplateName = template.Where(t => step.Where(p => pm.Select(item => item.ProcessId).Contains(p.ProcessId)).Select(p => p.TemplateId).AsEnumerable().Distinct().Contains(t.TemplateId)).Select(t => new TemplateInfo { TemplateId = t.TemplateId, TemplateName = t.TemplateName }).First(),
                            ComponentList = filter.Where(f => f.Apid == pm.Key).Select(f => new ApidNewEntity.ComponentInfo
                            {
                                ControlType = f.ControlType,
                                ControlIdDesc = f.ControlIdDesc,
                                Seq = f.Seq
                            }).ToList()
                        });

            Console.WriteLine(JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));

            Console.ReadLine();
        }
    }

    internal class ApidNewEntity
    {
        public string Apid { get; set; }

        public List<StepInfo> Steps { get; set; }

        public TemplateInfo TemplateName { get; set; }

        public List<ComponentInfo> ComponentList { get; set; }

        public class ComponentInfo
        {
            public int ControlType { get; set; }

            public string ControlIdDesc { get; set; }

            public int Seq { get; set; }
        }

        public class StepInfo
        {
            public string StepId { get; set; }

            public string StepName { get; set; }

            public string Descripion { get; set; }

            public int Seq { get; set; }
        }

        public class TemplateInfo
        {
            public string TemplateId { get; set; }

            public string TemplateName { get; set; }
        }
    }

    internal class FilterData
    {
        public string Apid { get; set; }

        public int ControlType { get; set; }

        public string ControlIdDesc { get; set; }

        public int Seq { get; set; }
    }

    internal class TemplateData
    {
        public string TemplateId { get; set; }

        public string TemplateName { get; set; }
    }

    internal class StepData
    {
        public string ProcessId { get; set; }

        public string ProcessName { get; set; }

        public string Description { get; set; }

        public string TemplateId { get; set; }
    }

    internal class ProcessData
    {
        public string Apid { get; set; }

        public string ProcessId { get; set; }

        public int Seq { get; set; }
    }
}
