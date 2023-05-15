using System;

class Program
{
    static void Main(string[] args)
    {
        // ส่วนของสวัสดิการน้ำ
        Console.WriteLine("Enter the water details:");
        Console.Write("Tank capacity: ");
        double Vmax = double.Parse(Console.ReadLine());
        Console.Write("Average water consumption during break: ");
        double VdrinkAvg = double.Parse(Console.ReadLine());
        Console.Write("Water filled in each refill: ");
        double Vfill = double.Parse(Console.ReadLine());

        // ส่วนของเหรัญญิก
        Console.WriteLine("Enter the payment details:");
        Console.Write("Balance 1: ");
        double B1 = double.Parse(Console.ReadLine());
        Console.Write("Balance 2: ");
        double B2 = double.Parse(Console.ReadLine());
        Console.Write("Balance 3: ");
        double B3 = double.Parse(Console.ReadLine());

        double L = 0;

        Console.WriteLine("Enter the payment amounts (enter negative or zero to stop):");
        while (true)
        {
            double payment = double.Parse(Console.ReadLine());
            if (payment <= 0)
                break;

            if (B1 >= payment)
            {
                B1 -= payment;
            }
            else if (B2 >= payment)
            {
                B2 -= payment;
            }
            else if (B3 >= payment)
            {
                B3 -= payment;
            }
            else
            {
                L += payment;
            }
        }

        // คำนวณปริมาณน้ำที่เหลือ
        double remainingWater = Vmax;
        double totalTime = 0;
        double breakInterval = 0;
        double fillInterval = 0;

        Console.Write("Enter break interval: ");
        breakInterval = double.Parse(Console.ReadLine());
        Console.Write("Enter fill interval: ");
        fillInterval = double.Parse(Console.ReadLine());
        Console.Write("Enter total activity time: ");
        totalTime = double.Parse(Console.ReadLine());

        double currentBreakTime = 0;
        double currentFillTime = fillInterval;
        while (currentBreakTime < totalTime)
        {
            if (currentFillTime == fillInterval)
            {
                if (remainingWater + Vfill <= Vmax)
                {
                    remainingWater += Vfill;
                    currentFillTime = 0;
                }
                else
                {
                    Console.WriteLine("Overflow Water");
                    break;
                }
            }

            if (currentBreakTime % breakInterval == 0 && currentBreakTime > 0)
            {
                if (remainingWater >= VdrinkAvg)
                {
                    remainingWater -= VdrinkAvg;
                }
                else
                {
                    Console.WriteLine("Not Enough Water");
                    break;
                }
            }

            currentBreakTime++;
            currentFillTime++;
        }

        if (currentBreakTime >= totalTime)
        {
            Console.WriteLine($"Enough Water, {remainingWater} left");
        }

        Console.WriteLine($"Balance 1: {B1}, Balance 2: {B2}, Balance 3: {B3}");
        Console.WriteLine($"Left: {L}");
    }
}