using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public delegate void MyDelegate(string text);

    enum MachineState
    {
        ZeroState,
        AccumulatorState,
        AccumulatorDecimalState,
        ComputedState,
        ResultState,
        ErrorState
    }

    class Brain
    {
        MyDelegate disSender;
        MachineState machine = MachineState.ZeroState;
        string currentNum = "";
        string resultNum = "";
        string operation = "";

        public Brain(MyDelegate myDelegate) 
        {
            disSender = myDelegate;
        }
        public void Process(string msg)
        {
            switch (machine)
            {
                case MachineState.ZeroState:
                    Zero(false, msg);
                    break;
                case MachineState.AccumulatorState:
                    AccumulateDigit(false, msg);
                    break;
                case MachineState.AccumulatorDecimalState:
                    break;
                case MachineState.ComputedState:
                    Compute(false, msg);
                    break;
                case MachineState.ResultState:
                    Equal(false, msg);
                    break;
                case MachineState.ErrorState:
                    break;
                default:
                    break;
            }
        }
        private void Zero(bool IsInput, string msg)
        {
            if (IsInput)
            {
                machine = MachineState.ZeroState;
            }
            else
            {
                if (Inputs.NonZeroDigit(msg))
                {
                    AccumulateDigit(true, msg);
                }
            }
        }

        private void AccumulateDigit(bool IsInput, string msg)
        {
            if (IsInput)
            {
                machine = MachineState.AccumulatorState;
                currentNum += msg;
                disSender(currentNum);
            }
            else
            {
                if(Inputs.NonZeroDigit(msg) || Inputs.IsZero(msg))
                {
                    AccumulateDigit(true, msg);
                }
                else if (Inputs.MathOp(msg))
                {
                    Compute(true, msg);
                }
                else if (Inputs.Equals(msg))
                {
                    Equal(true, msg);
                }
            }
        }

        private void Equal(bool IsEqual, string msg)
        {
            if (IsEqual)
            {
                machine = MachineState.ResultState;
                Calculate();
                disSender(resultNum);
            }
            else
            {
                if (Inputs.NonZeroDigit(msg))
                {
                    currentNum = "";
                    operation = "";
                    AccumulateDigit(true, msg);
                }
                else if (Inputs.IsZero(msg))
                {
                    currentNum = "";
                    operation = "";
                    Zero(true, msg);
                }
                else if (Inputs.MathOp(msg))
                {
                    operation = "";
                    currentNum = resultNum;
                    Compute(true, msg);
                }
            }
        }

        private void Compute(bool IsOperation, string msg)
        {
            if (IsOperation)
            {
                machine = MachineState.ComputedState;

                if(operation.Length > 0)
                {
                    Calculate();
                    disSender(resultNum);
                }
                else
                {
                    resultNum = currentNum;
                }
                currentNum = "";
                operation = msg;
            }
            else
            {
                if(Inputs.NonZeroDigit(msg) || Inputs.IsZero(msg))
                {
                    AccumulateDigit(true, msg);
                }
            }
        }

        private void Calculate()
        {
            if(operation == "+")
            {
                resultNum = (int.Parse(resultNum) + int.Parse(currentNum)).ToString();
            }
            else if (operation == "-")
            {
                resultNum = (int.Parse(resultNum) - int.Parse(currentNum)).ToString();
            }
            else if (operation == "*")
            {
                resultNum = (int.Parse(resultNum) * int.Parse(currentNum)).ToString();
            }
            else
            {
                resultNum = (double.Parse(resultNum) / double.Parse(currentNum)).ToString();
            }
        }
    }
}
