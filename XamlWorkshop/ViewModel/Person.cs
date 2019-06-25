using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XamlWorkshop.ViewModel
{
    public class Person : ViewModelBase
    {
        private int _age;

        [Browsable(false)]        
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                Set(ref _age, value);
            }
        }

        private Color _color;

        public Color Color
        {
            get
            {
                return _color;
            }

            set
            {
                Set(ref _color, value);
            }
        }

        private DateTime dateTime;

        public DateTime Birth
        {
            get
            {
                return dateTime;
            }

            set
            {
                Set(ref dateTime, value);
            }
        }


        private string _name;

        [Display(Order = 2, Name = "Nome", ShortName = "Short")]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                Set(ref _name, value);
            }
        }

        private string _job;

        [Display(Order = 2, Name = "Trabalho")]
        public string Job
        {
            get
            {
                return _job;
            }

            set
            {
                Set(ref _job, value);
            }
        }


    }
}
