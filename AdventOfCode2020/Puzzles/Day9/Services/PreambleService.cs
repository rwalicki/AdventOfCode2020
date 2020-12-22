using AdventOfCode2020.Puzzles.Day1.Services;
using AdventOfCode2020.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day9.Services
{
    public class PreambleService
    {
        private int _preambleValue;
        private SummaryFinder _summaryFinder;
        private ConverterService _converterService;

        public PreambleService(int preambleValue)
        {
            _preambleValue = preambleValue;
            _summaryFinder = new SummaryFinder();
            _converterService = new ConverterService();
        }

        public double FindInvalidElement(List<string> dataList)
        {
            var xmasData = _converterService.ConvertToDouble(dataList);
            var packets = MakePackets(xmasData);
            var packet = FindInvalidPacket(packets);
            return packet.LastOrDefault();
        }

        public double FindInvalidElement(List<double> xmasData)
        {
            var packets = MakePackets(xmasData);
            var packet = FindInvalidPacket(packets);
            return packet.LastOrDefault();
        }

        public List<List<double>> MakePackets(List<double> xmasData)
        {
            var list = new List<List<double>>();
            for (int i = 0; i < xmasData.Count - _preambleValue; i++)
            {
                var packet = new List<double>();
                for (int j = i; j <= i + _preambleValue; j++)
                {
                    packet.Add(xmasData[j]);
                }
                list.Add(packet);
            }
            return list;
        }

        private List<double> FindInvalidPacket(List<List<double>> packets)
        {
            foreach(var packet in packets)
            {
                var summary = packet.LastOrDefault();
                var result = _summaryFinder.FindAnySumOfTwoNumbers(packet, summary);
                if(result.Item1 == -1)
                {
                    return packet;
                }
            }
            return null;
        }

        public double FindContiguousSetResult(List<double> xmasData, double result)
        {
            var foundXmasData = _summaryFinder.FindContiguousSet(xmasData, result);
            var min = foundXmasData.Min();
            var max = foundXmasData.Max();
            return min + max;
        }

        public double FindContiguousSetResult(List<string> dataList, double result)
        {
            var xmasData = _converterService.ConvertToDouble(dataList);
            var foundXmasData = _summaryFinder.FindContiguousSet(xmasData, result);
            var min = foundXmasData.Min();
            var max = foundXmasData.Max();
            return min + max;
        }
    }
}
