
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Prism.Commands;
using RevitAPILibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_L6I_dElement
{
    public class MainViewViewModel
    {
        private ExternalCommandData _CommandData;

        public DelegateCommand SelectCommand { get; } //свойство

        public MainViewViewModel(ExternalCommandData commandData) //ctor = Конструктор// сюда будут передоваться данные по текущему открытому проекту Ревита
        {
            _CommandData = commandData; //сохраняем CommandData в отдельное поле, для того чтобы вызвать дукумент юайДокумент для взаиможействия с черт.
            SelectCommand = new DelegateCommand(OnSelectCommand);  //DelegateCommand-это конструктор из Prism, OnSelectCommand -сама команда,которая будет выполняться
        }
        /*
        //скрытие окна во время выбора элемента
        public event EventHandler CloseRequst;//событие
        public void RaiseCloseReqest()//метод для скрытия окна
        {
            CloseRequst?.Invoke(this,EventArgs.Empty); //если в нем есть методы то будем запускать те методы которые были привязанны к CloseRequst
            //далее нужно указать логику в коде относящемуся к окну
        }
        */
        public event EventHandler HideRequst;//событие
        public void RaiseHideReqest()//метод для временного скрытия окна
        {
            HideRequst?.Invoke(this, EventArgs.Empty); //если в нем есть методы то будем запускать те методы которые были привязанны к CloseRequst
            //далее нужно указать логику в коде относящемуся к окну
        }

        //скрытие окна во время выбора элемента
        public event EventHandler ShowRequst;//событие
        public void RaiseShowReqest()//метод для расскрытия окна
        {
            ShowRequst?.Invoke(this, EventArgs.Empty); //если в нем есть методы то будем запускать те методы которые были привязанны к CloseRequst
            //далее нужно указать логику в коде относящемуся к окну
        }


        private void OnSelectCommand() //метод  который будет выполняться(логика внутри указанной команды) при нажатии кнопки

        {
            RaiseHideReqest(); //будет запускаться при нажатии кнопки
                               //далее подключаемся к ревиту
            Element oElement = SelectionUtils.PickObject(_CommandData); //код в библиотеке

            TaskDialog.Show("Сообщение", $"ID: {oElement.Id}");
            RaiseShowReqest();
        }


    }
}
