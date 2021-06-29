using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using View = PicRotate0.View;

namespace PicRotate0
{
    public partial class ExistFile : Singleton<ExistFile>
    {
        public Action ChangeAction;
        public Action SkipAction;
        public Action CopyAndRenameAction;

        
        public ExistFile()
        {
            InitializeComponent();

        }

        private void Change_Click(object sender, EventArgs e)
        {
            ChangeAction?.Invoke();
        }

        private void Skip_Click(object sender, EventArgs e)
        {
            SkipAction?.Invoke();
        }

        private void CopyAndRename_Click(object sender, EventArgs e)
        {
            CopyAndRenameAction?.Invoke();
        }
    }
    public class Singleton<T> : Form
    {
        private static T instance;
        public static T GetInstance()
        {
            if (instance == null)
            {
                instance = Activator.CreateInstance<T>();
            }
            return instance;
        }
    }

    public class View : Form
    {

    }
}
