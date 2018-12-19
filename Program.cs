using System;
using System.Runtime.InteropServices;

namespace bladedotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var handle = GetDeviceHandle();
            AttachXB200(handle);
            Console.WriteLine("Device handle: " + handle);

            if (handle == IntPtr.Zero)
            {
                Console.WriteLine("No device detected");
                return;
            }

            var sampleRate = 5_000_000;
            var srResult = SetSampleRate(handle, 0, (int)sampleRate);
            Console.WriteLine("Set sample rate " + sampleRate + ": " + srResult);

            var centerFreq = 107_500_000;
            var cfResult = SetCenterFreq(handle, 0, (int)centerFreq);
            Console.WriteLine("Set center frequency " + centerFreq + ": " + cfResult);
        }

        public static IntPtr GetDeviceHandle()
        {
            IntPtr handle;
            BladeRFOpen(out handle, null);
            return handle;
        }

        public static bool SetSampleRate(IntPtr handle, int channel, int sampleRate)
        {
            int current;
            BladeRFSetSampleRate(handle, channel, sampleRate, out current);
            return current == sampleRate;
        }

        public static bool SetCenterFreq(IntPtr handle, int channel, int centerFreq)
        {
            int result = BladeRFSetFrequency(handle, channel, centerFreq);
            return result == 0;
        }

        public static void AttachXB200(IntPtr handle)
        {
            BladeRFExpansionAttach(handle, 2);
            BladeRFXB200SetFilterbank(handle, 0, 3);
        }

        [DllImport(dllName: "libbladeRF", EntryPoint="bladerf_open")]
        public static extern int BladeRFOpen(out IntPtr handle, string id);

        [DllImport(dllName: "libbladeRF", EntryPoint="bladerf_set_sample_rate")]
        public static extern int BladeRFSetSampleRate(IntPtr handle, int channel, int value, out int current);

        [DllImport(dllName: "libbladeRF", EntryPoint="bladerf_set_frequency")]
        public static extern int BladeRFSetFrequency(IntPtr handle, int channel, int value);

        [DllImport(dllName: "libbladeRF", EntryPoint="bladerf_expansion_attach")]
        public static extern int BladeRFExpansionAttach(IntPtr handle, int xb);

        [DllImport(dllName: "libbladeRF", EntryPoint="bladerf_xb200_set_filterbank")]
        public static extern int BladeRFXB200SetFilterbank(IntPtr handle, int channel, int filter);
    }
}
