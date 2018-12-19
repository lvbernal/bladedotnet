bladeRF-cli -l fpga_115_0_9_0.rbf

dotnet new console

bladeRF> info

  Board:                    Nuand bladeRF (bladerf1)
  Serial #:                 f8307360ed61a035f956888de2d1433c
  VCTCXO DAC calibration:   0x97ab
  FPGA size:                115 KLE
  FPGA loaded:              yes
  Flash size:               32 Mbit (assumed)
  USB bus:                  20
  USB address:              3
  USB speed:                SuperSpeed
  Backend:                  libusb
  Instance:                 0

bladeRF> xb 200 enable
bladeRF> xb 200 filter rx custom

Método bladerf_open()
https://nuand.com/libbladeRF-doc/v2.1.0/group___f_n___i_n_i_t.html#gab341ac98615f393da9158ea59cdb6a24