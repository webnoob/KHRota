using System.Windows.Forms;
using KHRota.Services;

namespace KHRota.Forms
{
    public class BaseForm : Form
    {
        protected DbService DbService;

        protected BaseForm()
        {
            DbService = new DbService();
        }
    }
}
