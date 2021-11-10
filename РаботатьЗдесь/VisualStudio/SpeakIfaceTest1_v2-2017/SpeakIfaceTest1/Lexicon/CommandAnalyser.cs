﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Operator.Lexicon
{
    /// <summary>
    /// Анализатор команды - для исполнения сложных и составных команд 
    /// </summary>
    public  class CommandAnalyser
    {

        /// <summary>
        /// NT-Разобрать входной запрос команды, построить граф исполнения и исполнить команду
        /// </summary>
        /// <param name="engine">Объект движка</param>
        /// <param name="query">Текст исходного запроса</param>
        /// <returns></returns>
        internal static ProcedureResult ProcessQuery(Engine engine, string query)
        {
            //сейчас тупо исполним весь запрос целиком
            ProcedureResult result = engine.DoQuery(query);

            //а вообще это неправильно - для составных команд надо:
            //1. попытаться найти для нее процедуру-исполнителя как есть. Но найти и не исполнять пока!
            //2. если не нашлось, то пытаться разделить запрос на части по смыслу, и пытаться найти для них процедуру-исполнителя. Но найти и не исполнять пока!
            //3. если не нашлось процедуры хотя бы для одной из частей запроса, исполнять команду нельзя!
            //В итоге, это все не вписывается в существующую архитектуру системы. Надо все переделывать для поддержки составных команд.
            //а тут - пока - можно приводить глаголы в команде к первичной форме: спи = спать, найди = найти. 
            //Вот и вся интеллектуальная обработка тут.

            return result;
        }
    }
}
