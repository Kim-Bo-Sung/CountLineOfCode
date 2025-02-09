namespace MyMessage
{
    internal class MyMessageBox
    {
        public static DialogResult Show(string text)
            => new FormMessageBox(text).ShowDialog();
        public static DialogResult Show(string text, string caption)
            => new FormMessageBox(text, caption).ShowDialog();
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
            => new FormMessageBox(text, caption, buttons).ShowDialog();
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
            => new FormMessageBox(text, caption, buttons, icon).ShowDialog();
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
            => new FormMessageBox(text, caption, buttons, icon, defaultButton).ShowDialog();

        /*
         * -> IWin32Window Owner:
         *    Displays a message box in front of the specified object and with the other specified parameters.
         *    An implementation of IWin32Window that will own the modal dialog box.
         */
        public static DialogResult Show(IWin32Window owner, string text)
            => new FormMessageBox(text).ShowDialog(owner);
        public static DialogResult Show(IWin32Window owner, string text, string caption)
            => new FormMessageBox(text, caption).ShowDialog(owner);
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
            => new FormMessageBox(text, caption, buttons).ShowDialog(owner);
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
            => new FormMessageBox(text, caption, buttons, icon).ShowDialog(owner);
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
            => new FormMessageBox(text, caption, buttons, icon, defaultButton).ShowDialog(owner);
    }
}
