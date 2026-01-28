using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelCalcul.Model
{
    public static class Calculator
    {  
        public static void GetDifference(double number, Action<double> callback, CancellationToken cancellationToken)
        {
            double previous = 0;
            double difference = 0;

            for (int i = 1; i <= number; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                difference = i - previous;  // Разность между текущим и предыдущим
                previous = i;
                Thread.Sleep(10);
            }

            callback.Invoke(difference); //последняяя разность
        }


        public static void GetSum(double number, Action<double> callback, CancellationToken cancellationToken)
        {
            double sum = 0;

            for (int i = 1; i <= number; i++)
            {
                cancellationToken.ThrowIfCancellationRequested(); // проверка, если операция отменена
                sum += i;
                Thread.Sleep(10); 
            }

            callback.Invoke(sum);
        }
    }
}
