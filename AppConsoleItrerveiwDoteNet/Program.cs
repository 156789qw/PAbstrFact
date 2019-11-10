using System;
using System.Collections.Generic;

namespace AppConsoleItrerveiwDoteNet
{
    class Program
    {
        // в моделях для вью можно задать только сразу все параметры для колонки

        static void Main()
        {
            // Вибираем какую строку нужно производить, т.к. фабрика вернет строку
            IInput factory = null;
            //var theProductIs = "InputTextWithMultySelect";
            var theProductIs = "InputTextWithFilter";
            if (theProductIs == "InputTextWithFilter")
            {
                factory = new InputWithFilter();
            }
            if (theProductIs == "InputTextWithMultySelect")
            {
                factory = new InputWithMultySelect();
            }
            var clientAplicationInput = new ClientAplication(factory);
            // выбираем что из строки нужно
            var textInput = clientAplicationInput.CreateTextInput();
            var dropDownInput = clientAplicationInput.CreateDropDownInput();

        }

        //static void a_MultipleOfFiveReached(object sender, MultipleOfFiveEventArgs e)
        //{
        //    Console.WriteLine("Multiple of five reached: ", e.Total);
        //}


    }

    public class ClientAplication
    {
        private IInput _factory;
        //private ITextInput _textInput;
        //private IDropDownInput _dropDownInput;
        public ClientAplication(IInput factory)
        {
            _factory = factory;
        }
        public InputTextControl CreateTextInput()
        {
            return _factory.CreateTextInput().Create();
        }
        public InputDropDownControl CreateDropDownInput()
        {
            return _factory.CreateDropDownInput().Create();
        }
    }


    // Это продукт он выполнен как общий интерфейс, это колонка
    public interface ITextInput
    {
        InputTextControl Create();
    }
    // Конкретная реализация общего интерфейса, это строка
    public class TextInputWithFilter : ITextInput
    {
        public InputTextControl Create()
        {
            return new InputTextControl { Name = "TextInputWithFilter" };
        }
    }
    // Конкретная реализация общего интерфейса, это строка
    public class TextInputWithMultySelect : ITextInput
    {
        public InputTextControl Create()
        {
            return new InputTextControl { Name = "TextInputWithMultySelect" };
        }
    }

    // Это продукт он выполнен как общий интерфейс, это колонка
    public interface IDropDownInput
    {
        InputDropDownControl Create();
    }
    // Конкретная реализация общего интерфейса, это строка
    public class DropDownWithFilter : IDropDownInput
    {
        public InputDropDownControl Create()
        {
            return new InputDropDownControl { Name = "DropDownWithFilter" };
        }
    }
    // Конкретная реализация общего интерфейса, это строка
    public class DropDownWithMultySelect : IDropDownInput
    {
        public InputDropDownControl Create()
        {
            return new InputDropDownControl { Name = "DropDownWithMultySelect" };
        }
    }

    // Абстрактная фабрика производит продукт, для всех колонок
    public interface IInput
    {
        ITextInput CreateTextInput();
        IDropDownInput CreateDropDownInput();
    }
    // Конкретная фабрика (одна из для конкретной реализаци
    // которая нужна) это производит ячейки в строке
    public class InputWithFilter : IInput
    {
        public ITextInput CreateTextInput()
        {
            return new TextInputWithFilter();
        }

        public IDropDownInput CreateDropDownInput()
        {
            return new DropDownWithFilter();
        }
    }
    // Конкретная фабрика (одна из для конкретной реализаци
    // которая нужна) это производит ячейки в строке
    public class InputWithMultySelect : IInput
    {
        public ITextInput CreateTextInput()
        {
            return new TextInputWithMultySelect();
        }
        public IDropDownInput CreateDropDownInput()
        {
            return new DropDownWithMultySelect();
        }
    }
    
    // модели для передачи данных на вью
    public class InputControl
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }
    // Модель для колонки
    public class InputTextControl: InputControl
    {
        public string FilterData { get; set; }
        public List<string> MultyData { get; set; }
    }

    // Модель для колонки
    public class InputDropDownControl : InputControl
    {
        public List<string> MultySelectOptions { get; set; }
        public string FilterData { get; set; }
        public List<string> MultyData { get; set; }
    }
}
