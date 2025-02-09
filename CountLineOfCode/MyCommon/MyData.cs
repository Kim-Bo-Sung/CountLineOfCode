using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommon
{
    public class FileInfo
    {
        public string? OpenFilePath { get; set; }
        public string? SaveFilePath { get; set; }
        public List<CodeInfo>? CodeFileList { get; set; }
        public bool IsShown { get; set; } = false;
        public int CodeLinesTotalSum { get; set; } = 0;
        public int CommentLinesTotalSum { get; set; } = 0;
        public int EmptyLinesTotalSum { get; set; } = 0;
        public int TotalLinesTotalSum { get; set; } = 0;
    }

    public class CodeInfo
    {
        public string? CodeFileName { get; set; }
        public int CodeLines { get; set; } = 0;
        public int CommentLines { get; set; } = 0;
        public int EmptyLines { get; set; } = 0;
        public int TotalLines { get; set; } = 0;
        public int CodeLinesSum { get; set; } = 0;
        public int CommentLinesSum { get; set; } = 0;
        public int EmptyLinesSum { get; set; } = 0;
        public int TotalLinesSum { get; set; } = 0;
    }
}
