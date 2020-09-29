using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCut.src.model
{
    public interface NotifyEventListener
    {
        void onOkClicked();
        void onCancelClicked();
    }
}
