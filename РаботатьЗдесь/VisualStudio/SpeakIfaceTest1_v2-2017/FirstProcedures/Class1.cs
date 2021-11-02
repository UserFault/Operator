using System;
using System.Collections.Generic;
using System.Text;
using SpeakIfaceTest1;
using SpeakIfaceTest1.Lexicon;


namespace FirstProcedures
{
    public static class Procedures 
    {
        ///// <summary>
        ///// Пример функции процедуры обработчика команды
        ///// </summary>
        ///// <param name="engine">Механизм исполнения команд</param>
        ///// <param name="cmdline">Текст запроса для возможной дополнительной обработки</param>
        ///// <param name="args">Список аргументов</param>
        ///// <returns>
        ///// Вернуть ProcedureResult.Success в случае успешного выполнения команды.
        ///// Вернуть ProcedureResult.WrongArguments если аргументы не подходят для запуска команды.
        ///// Вернуть ProcedureResult.Error если произошла ошибка при выполнении операции
        ///// Вернуть ProcedureResult.ExitXXX если нужно завершить работу текущего приложения, выключить или перезагрузить компьютер.
        ///// </returns>
        //[ProcedureAttribute(ImplementationState.NotTested)]//изменить состояние на подходящее после отладки функции
        //public static ProcedureResult CommandHandlerExample(Engine engine, string cmdline, ArgumentCollection args)
        //{
        //    //вернуть флаг продолжения работы
        //    return ProcedureResult.Success;
        //}

        /// <summary>
        /// Первая функция процедуры обработчика команды
        /// </summary>
        /// <param name="engine">Механизм исполнения команд</param>
        /// <param name="cmdline">Текст запроса для возможной дополнительной обработки</param>
        /// <param name="args">Список аргументов</param>
        /// <returns></returns>
        [ProcedureAttribute(ImplementationState.NotTested)]
        public static ProcedureResult CommandHandlerExample(Engine engine, string query, ArgumentCollection args)
        {
            engine.OperatorConsole.PrintTextLine("Message from command handler function", DialogConsoleColors.Сообщение);
            //вернуть флаг продолжения работы
            return ProcedureResult.Success;
        }

    }
}
