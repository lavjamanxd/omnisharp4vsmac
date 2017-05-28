using System.Threading;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using OmniSharp.Server;
using OmniSharp.Server.Communication.Messages;

namespace Command
{
    public class RenameCommand : CommandHandler
    {
        void HandleAction(string buffer)
        {
            var editor = IdeApp.Workbench.ActiveDocument.Editor;

            Runtime.RunInMainThread(() =>
            {
                var a = new MonoDevelop.Refactoring.TextReplaceChange();
                a.FileName = editor.FileName;
                a.InsertedText = buffer;
                a.Offset = 0;
                a.RemovedChars = editor.Text.Length;
                a.MoveCaretToReplace = false;
                a.PerformChange(new ProgressMonitor(), new MonoDevelop.Refactoring.RefactoringOptions { });
            });
        }

        protected override void Run(object dataItem)
        {
            var editor = IdeApp.Workbench.ActiveDocument.Editor;
            var caretPosition = editor.CaretLocation;
            Server.Instance.ExecuteRequest(new RenameRequest(caretPosition.Line, caretPosition.Column).ToString(), HandleAction);
            base.Run(dataItem);
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
            base.Update(info);
        }
    }
}