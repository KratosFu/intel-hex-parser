using System;

namespace IntelHexParser.Coshx.Com {
    internal class Record {        
        internal int Type { get; set; }
        internal int DataLength { get; set; }
        internal UInt16 Address { get; set; }
        internal byte[] Data { get; set; }
        
        internal byte Checksum {
            get {
                byte checksum;
                
                checksum = (byte) DataLength;
                checksum += (byte) Type;
                checksum += (byte) Address;
                checksum += (byte) ((Address & 0xFF00) >> 8);
                
                for (int i = 0; i < DataLength; i++) {
                    checksum += Data[i];
                }
                
                checksum = (byte) (~checksum + 1);
                
                return checksum;
            }
        }
        
        internal override String ToString() {
            String outcome;
            
            outcome = String.Format("{0}{1:X2}{2:X4}{3:X2}", ':', DataLength, Address, Type);
            
            for (int i = 0; i < DataLength; i++) {
                outcome += String.Format("{0:X2}",  Data[i]);
            }
            
            outcome += String.Format("{0:X2}",  Checksum);
            
            return outcome;
        }
    } 
}