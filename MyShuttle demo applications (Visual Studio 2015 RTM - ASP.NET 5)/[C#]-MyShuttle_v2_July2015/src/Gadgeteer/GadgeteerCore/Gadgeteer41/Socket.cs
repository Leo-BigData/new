////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Gadgeteer
{
    using Microsoft.SPOT;
    using Microsoft.SPOT.Hardware;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using Gadgeteer.Modules;


    /// <summary>
    /// A class representing a socket, which may be on a mainboard or on an expansion module such as an SPI multiplexer.  
    /// </summary>
    /// <remarks>
    /// This class is normally not directly used by application programs, who refer to sockets by their socket number. 
    /// Modules should normally use this class and the GT.Interfaces classes to access functionality required to implement their APIs.
    /// Mainboards and multiplexer modules providing sockets should use this class's SocketInterfaces subclass to declare functionalities provided on their sockets.
    /// </remarks>
    public class Socket
    {
        /// <summary>
        /// The socket number corresponding to this socket.  On mainboards, this is a positive number and is printed on the board itself. 
        /// For module-provided sockets (i.e. sockets you plug other modules into) this is an automatically generated negative number.
        /// </summary>
        public int SocketNumber { get; private set; }

        /// <summary>
        /// The name of the socket.  This is shown to users in any socket-related error messages generated by Gadgeteer Core.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Array of pins used by the socket.  This is always of size 11, with index [1] to [10] being the relevant Cpu.Pin for the Socket.Pin.
        /// Index 0 is unused.
        /// </summary>
        public Cpu.Pin[] CpuPins { get; private set; }

        /// <summary>
        /// The supported types of this socket.  
        /// </summary>
        public char[] SupportedTypes
        {
            get
            {
                return _SupportedTypes;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _SupportedTypes = value;
            }
        }
        private char[] _SupportedTypes;

        /// <summary>
        /// The SPI_module corresponding to this socket.  This is Socket.SPIMissing if there is no SPI module on this socket.
        /// </summary>
        public SPI.SPI_module SPIModule
        {
            get
            {
                return _SPIModule;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _SPIModule = value;
            }
        }
        private SPI.SPI_module _SPIModule;

        /// <summary>
        /// Returns the serial port name (e.g. "COM1") associated with a particular socket. 
        /// </summary>
        /// <remarks>
        /// Throws an ArgumentException if the socket does not support socket type U or socket type K.
        /// </remarks>
        /// <returns>The serial port name</returns>
        public string SerialPortName {
            get
            {
                return _serialPortName;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _serialPortName = value;
            }
        }
        private string _serialPortName;

        /// <summary>
        /// Provides access to pulse width modulation (PWM) functionality on a socket pin 7.
        /// </summary>
        /// <remarks>
        /// Relies on native or hardware support for PWM provided by the mainboard manufacturer.
        /// </remarks>
        /// <returns>An instance of the SocketInterfaces.PWM interface, which provides access to underlying PWM functionality.</returns>
        public SocketInterfaces.PWM PWM7 {
            get
            {
                return _PWM7;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _PWM7 = value;
            }
        }
        private SocketInterfaces.PWM _PWM7;

        /// <summary>
        /// Provides access to pulse width modulation (PWM) functionality on a socket pin 8.
        /// </summary>
        /// <remarks>
        /// Relies on native or hardware support for PWM provided by the mainboard manufacturer.
        /// </remarks>
        /// <returns>An instance of the SocketInterfaces.PWM interface, which provides access to underlying PWM functionality.</returns>
        public SocketInterfaces.PWM PWM8
        {
            get
            {
                return _PWM8;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _PWM8 = value;
            }
        }
        private SocketInterfaces.PWM _PWM8;

        /// <summary>
        /// Provides access to pulse width modulation (PWM) functionality on a socket pin 9.
        /// </summary>
        /// <remarks>
        /// Relies on native or hardware support for PWM provided by the mainboard manufacturer.
        /// </remarks>
        /// <returns>An instance of the SocketInterfaces.PWM interface, which provides access to underlying PWM functionality.</returns>
        public SocketInterfaces.PWM PWM9
        {
            get
            {
                return _PWM9;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _PWM9 = value;
            }
        }
        private SocketInterfaces.PWM _PWM9;

        /// <summary>
        /// Provides access to analog input functionality on a socket's pin 3.
        /// </summary>
        /// <remarks>
        /// Relies on native or hardware support for analog input provided by the mainboard manufacturer.
        /// </remarks>
        /// <returns>An instance of the SocketInterfaces.AnalogInput class, which provides access to underlying analog input functionality.</returns>
        public SocketInterfaces.AnalogInput AnalogInput3 {
            get
            {
                return _AnalogInput3;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _AnalogInput3 = value;
            }
        }
        private SocketInterfaces.AnalogInput _AnalogInput3;

        /// <summary>
        /// Provides access to analog input functionality on a socket's pin 4.
        /// </summary>
        /// <remarks>
        /// Relies on native or hardware support for analog input provided by the mainboard manufacturer.
        /// </remarks>
        /// <returns>An instance of the SocketInterfaces.AnalogInput class, which provides access to underlying analog input functionality.</returns>
        public SocketInterfaces.AnalogInput AnalogInput4 {
            get
            {
                return _AnalogInput4;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _AnalogInput4 = value;
            }
        }
        private SocketInterfaces.AnalogInput _AnalogInput4;

        /// <summary>
        /// Provides access to analog input functionality on a socket's pin 5.
        /// </summary>
        /// <remarks>
        /// Relies on native or hardware support for analog input provided by the mainboard manufacturer.
        /// </remarks>
        /// <returns>An instance of the SocketInterfaces.AnalogInput class, which provides access to underlying analog input functionality.</returns>
        public SocketInterfaces.AnalogInput AnalogInput5 {
            get
            {
                return _AnalogInput5;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _AnalogInput5 = value;
            }
        }
        private SocketInterfaces.AnalogInput _AnalogInput5;

        /// <summary>
        /// Provides access to analog output functionality on a socket. 
        /// </summary>
        /// <remarks>
        /// Relies on native or hardware support for analog output provided by the mainboard manufacturer.
        /// </remarks>
        /// <returns>An instance of the SocketInterfaces.AnalogOutput class, which provides access to underlying analog output functionality.</returns>
        public SocketInterfaces.AnalogOutput AnalogOutput {
            get
            {
                return _AnalogOutput;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _AnalogOutput = value;
            }
        }
        private SocketInterfaces.AnalogOutput _AnalogOutput;
        
        /// <summary>
        /// NativeI2C functionality provided by the socket.  Null if not available on this socket.
        /// </summary>
        public SocketInterfaces.NativeI2CWriteReadDelegate NativeI2CWriteRead {
            get
            {
                return _NativeI2CWriteRead;
            }
            set
            {
                if (_registered) throw new SocketImmutableAfterRegistrationException();
                _NativeI2CWriteRead = value;
            }
        }
        private SocketInterfaces.NativeI2CWriteReadDelegate _NativeI2CWriteRead;

        internal static ArrayList _sockets = new ArrayList();

        /// <summary>
        /// A special socket number indicating that a module socket is not used.
        /// </summary>
        public static int Unused { get { return int.MinValue; } }

        /*
        /// <summary>
        /// Get the <see cref="Socket"/> corresponding to a socket number.
        /// </summary>
        /// <param name="socketNumber">The socket number</param>
        /// <param name="throwExceptionIfSocketNumberInvalid">Whether to throw an <see cref="InvalidSocketException"/> if the socket does not exist.</param>
        /// <returns>The socket corresponding to the provided socket number.</returns>
        public static Socket GetSocket(int socketNumber, bool throwExceptionIfSocketNumberInvalid)
        {
            return GetSocket(socketNumber, throwExceptionIfSocketNumberInvalid, null, null);
        }*/

        /// <summary>
        /// Get the <see cref="Socket"/> corresponding to a socket number.
        /// </summary>
        /// <param name="socketNumber">The socket number</param>
        /// <param name="throwExceptionIfSocketNumberInvalid">Whether to throw an <see cref="InvalidSocketException"/> if the socket does not exist.</param>
        /// <param name="module">The module using this socket.</param>
        /// <param name="socketLabel">The label on the socket, if there is more than one socket on the module (can be null).</param>
        /// <returns>The socket corresponding to the provided socket number.</returns>
        public static Socket GetSocket(int socketNumber, bool throwExceptionIfSocketNumberInvalid, Module module, string socketLabel)
        {
            if(socketLabel == "") socketLabel = null;

            if (socketNumber == Socket.Unused)
            {
                if (throwExceptionIfSocketNumberInvalid)
                {
                    if(module == null) 
                    {
                        throw new InvalidSocketException("Cannot get Socket for socket number Socket.NotConnected");
                    } 
                    else 
                    {
                        String errormessage = "Module " + module;
                        if(socketLabel != null) errormessage += " socket " + socketLabel;
                        errormessage += " must have a valid socket number specified (it does not support Socket.Unused)";
                        throw new InvalidSocketException(errormessage);
                    }
                }
                else
                {
                    return null;
                }
            }

            lock (_sockets)
            {
                foreach (Socket socket in _sockets)
                {
                    if (socket.SocketNumber == socketNumber) return socket;
                }
            }
            if (throwExceptionIfSocketNumberInvalid)
            {
                if (module == null)
                {
                    throw new InvalidSocketException("Invalid socket number " + socketNumber + " specified.");
                }
                else
                {
                    String errormessage = "Module " + module;
                    if (socketLabel != null) errormessage += " socket " + socketLabel;
                    errormessage += " cannot be used with invalid socket number " + socketNumber;
                    throw new InvalidSocketException(errormessage);
                }
            }
            return null;
        }

        internal static readonly SPI.SPI_module SPIMissing = (SPI.SPI_module)(-1);
        internal bool _registered = false;

        internal Socket(int socketNumber, string name)
        {
            this.Name = name;
            this.SocketNumber = socketNumber;
            this.SerialPortName = null;
            this.PWM7 = null;
            this.PWM8 = null;
            this.PWM9 = null;
            this.AnalogInput3 = null;
            this.AnalogInput4 = null;
            this.AnalogInput5 = null;
            this.AnalogOutput = null;
            this.NativeI2CWriteRead = null;
            this.SPIModule = SPIMissing;
            this.SupportedTypes = new char[0] { };
            this.CpuPins = new Cpu.Pin[11];
            this._registered = false;
            for (int i = 0; i < 11; i++)
            {
                CpuPins[i] = Socket.UnspecifiedPin;
            }
        }

        /// <summary>
        /// Returns the Name of this socket.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }


        /// <summary>
        /// Determines whether the specified socket supports the given socket type
        /// </summary>
        /// <param name="type">The socket type</param>
        /// <returns></returns>
        public bool SupportsType(char type)
        {
            foreach(char supportedType in SupportedTypes) 
            {
                if(type==supportedType) return true;
            }

            return false;
        }

        /// <summary>
        /// Checks that a given socket type is supported, and throws an <see cref="InvalidSocketException"/> if not. Optionally specifies the module which requires this type, resulting in a better error message.
        /// </summary>
        /// <param name="type">The socket type required.</param>
        /// <param name="module">The module requiring this socket type (can be null).</param>
        public void EnsureTypeIsSupported(char type, Module module)
        {
            if(!SupportsType(type)) {
                throw new InvalidSocketException("Socket " + Name + " does not support type '" + type + "'" + (module != null ? "  required by " + module + " module." : "."));
            }
        }

        /// <summary>
        /// Checks that one of a given set of socket types is supported, and throws an <see cref="InvalidSocketException"/> if not. Optionally specifies the module which requires this type, resulting in a better error message.
        /// </summary>
        /// <param name="types">The array of socket types required (any one of these is sufficient).</param>
        /// <param name="module">The module requiring this socket type (can be null).</param>
        public void EnsureTypeIsSupported(char[] types, Module module)
        {
            foreach (char type in types)
            {
                if (SupportsType(type)) return;
            }
            throw new InvalidSocketException("Socket " + Name + " does not support one of the types '" + new String(types) + "'" + (module != null ? "  required by " + module + " module." : "."));
        }

        /// <summary>
        /// An enumeration of socket pins.
        /// </summary>
        public enum Pin
        {
            /// <summary>
            /// Socket pin 1
            /// </summary>
            One = 1,
            /// <summary>
            /// Socket pin 2
            /// </summary>
            Two = 2,
            /// <summary>
            /// Socket pin 3
            /// </summary>
            Three = 3,
            /// <summary>
            /// Socket pin 4
            /// </summary>
            Four = 4,
            /// <summary>
            /// Socket pin 5
            /// </summary>
            Five = 5,
            /// <summary>
            /// Socket pin 6
            /// </summary>
            Six = 6,
            /// <summary>
            /// Socket pin 7
            /// </summary>
            Seven = 7,
            /// <summary>
            /// Socket pin 8
            /// </summary>
            Eight = 8,
            /// <summary>
            /// Socket pin 9
            /// </summary>
            Nine = 9,
            /// <summary>
            /// Socket pin 10
            /// </summary>
            Ten = 10
        }

        private static ArrayList _reservedPins = new ArrayList();

        internal class PinReservation
        {
            public Socket ReservingSocket { get; private set; }
            public Socket.Pin ReservingPin { get; private set; }
            public Cpu.Pin CpuPin { get; private set; }
            public Module ReservingModule { get; private set; }

            public PinReservation(Socket socket, Socket.Pin pin, Cpu.Pin cpuPin, Module module)
            {
                ReservingSocket = socket;
                ReservingModule = module;
                ReservingPin = pin;
                CpuPin = cpuPin;
            }
        }
        
        /// <summary>
        /// Tells GadgeteerCore that a pin is being used on this socket.  A <see cref="PinConflictException"/> will be thrown if the pin is already reserved.
        /// This is called by Gadgteeer.Interface classes automatically.  Gadgeteer.Modules which do not use a Gadgeteer.Interface helper class in using a pin should call this directly.
        /// Note that Gadgeteer allows mainboard pins to be reused across multiple sockets, so the reservation check also checks if the pin is used on a different socket where the pin is shared.
        /// </summary>
        /// <param name="pin">The socket pin being used</param>
        /// <param name="module">The module using the socket pin (can be null, but if it is not null a more useful error message will be generated).</param>
        /// <returns></returns>
        public Cpu.Pin ReservePin(Socket.Pin pin, Module module)
        {
            Cpu.Pin cpuPin = CpuPins[(int)pin];
            if (cpuPin == UnspecifiedPin)
            {
                throw new PinMissingException(this, pin);
            }

            if (cpuPin == UnnumberedPin)
            {
                // bypass checks, return no pin
                return Cpu.Pin.GPIO_NONE;
            }

            // Check to see if pin is already reserved
            foreach (PinReservation reservation in _reservedPins)
            {
                if (cpuPin == reservation.CpuPin)
                {
                    throw new PinConflictException(this, pin, module, reservation);
                }
            }

            // see if this is a display socket and reboot if we need to disable the LCD controller
            if (!(module is Module.DisplayModule) && (SupportsType('R') || SupportsType('G') || SupportsType('B')))
            {
                Module.DisplayModule.LCDControllerPinReuse();
            }

            _reservedPins.Add(new PinReservation(this, pin, cpuPin, module));
            return cpuPin;
        }

        /// <summary>
        /// An exception raised when a socket pin which is unspecified by the socket provider is used.
        /// </summary>
        public class PinMissingException : ApplicationException
        {
            internal PinMissingException(Socket socket, Socket.Pin pin)
                : base("\nPin " + (int)pin + " on socket " + socket + " is not connected to a valid CPU pin.")
            { }
        }

        /// <summary>
        /// An exception raised when there is a pin conflict.
        /// </summary>
        public class PinConflictException : ApplicationException
        {
            internal PinConflictException(Socket socket, Socket.Pin pin, Module module, PinReservation priorReservation)
                : base("\nUnable to configure the " + (module != null ? module + " " : "") + "module using socket " + socket + " (pin " + (int)pin + "). " +
                "There is a conflict with the " + (priorReservation.ReservingModule != null ? priorReservation.ReservingModule + " " : "") + "module using socket " +
                priorReservation.ReservingSocket + " (pin " + priorReservation.ReservingPin + "). Please try using a different combination of sockets.")
            { }
        }

        /// <summary>
        /// An exception raised when an invalid socket is specified, e.g. a socket incompatible with the functionality required. 
        /// </summary>
        public class InvalidSocketException : ArgumentException
        {
            /// <summary>
            /// Generates a new invalid socket exception
            /// </summary>
            /// <param name="message">The exception cause</param>
            public InvalidSocketException(String message)
                : base(message)
            {
            }

            /// <summary>
            /// Generates a new invalid socket exception
            /// </summary>
            /// <param name="message">The exception cause</param>
            /// <param name="e">The underlying exception</param>
            public InvalidSocketException(String message, Exception e)
                : base(message, e)
            {
            }
        }

        /// <summary>
        /// This exception is thrown when a socket which is already registered with GadgeteerCore is then modified.
        /// </summary>
        public class SocketImmutableAfterRegistrationException : InvalidOperationException
        {
            internal SocketImmutableAfterRegistrationException()
                : base("Socket data is immutable after socket is registered.")
            { }
        }

        /// <summary>
        /// A CPU pin which has no number, and for which reservation does not need to be tracked.
        /// </summary>
        public static readonly Cpu.Pin UnnumberedPin = (Cpu.Pin)int.MinValue;

        /// <summary>
        /// An unspecified CPU pin (e.g. for a socket which does not use this pin).
        /// </summary>
        public static readonly Cpu.Pin UnspecifiedPin = Cpu.Pin.GPIO_NONE;

        /// <summary>
        /// This static class contains interfaces used by mainboards to provide functionalities on sockets to Gadgeteer.  
        /// End users do not need to use this class directly and should normally use GTM.Modules to access functionality.
        /// Module developers do not need to use this class directly and should normally use GT.Socket and GT.Interfaces to access the required functionality.
        /// </summary>
        public static class SocketInterfaces
        {
            /// <summary>
            /// Creates a new <see cref="Socket"/> object specifying the socket number.
            /// </summary>
            /// <remarks>
            /// This should be used by the mainboard's constructor to create socket instances,
            /// which should then configure the socket properties as appropriate, and then call <see cref="RegisterSocket"/>
            /// NB the socket name is fixed to be the same as the socket number.
            /// </remarks>
            /// <param name="socketNumber">The mainboard socket number</param>
            public static Socket CreateNumberedSocket(int socketNumber)
            {
                return new Socket(socketNumber, socketNumber.ToString());
            }

            /// <summary>
            /// Creates a new <see cref="Socket"/> object specifying the socket name.
            /// </summary>
            /// <remarks>
            /// This should be used by module constructors to create socket instances if they provide sockets to other modules.  
            /// The module constructor should then configure the socket properties as appropriate, and then call <see cref="RegisterSocket"/>
            /// A socketNumber is auto-assigned.
            /// </remarks>
            /// <param name="name">The socket's name</param>
            public static Socket CreateUnnumberedSocket(String name)
            {
                int socketNumber;
                lock (Socket._sockets)
                {
                    while (Socket.GetSocket(autoSocketNumber, false, null, null) != null) autoSocketNumber--;
                    socketNumber = autoSocketNumber;
                    autoSocketNumber--;
                }
                return new Socket(socketNumber, name);
            }
            private static int autoSocketNumber = -10;

            private static bool DoRegistrationChecks = true;

            private static void SocketRegistrationError(Socket socket, string message)
            {
                Debug.Print("Warning: socket " + socket + " is not compliant with Gadgeteer : " + message);
            }

            private static void TestPinsPresent(Socket socket, int[] pins, char type)
            {
                foreach (int pin in pins)
                {
                    if (socket.CpuPins[pin] == Socket.UnspecifiedPin) SocketRegistrationError(socket, "Cpu pin " + pin + " must be specified for socket of type " + type);
                }
            }

            /// <summary>
            /// Registers a socket.  Should be used by mainboards and socket-providing modules during initialization.
            /// </summary>
            /// <param name="socket">The socket to register</param>
            public static void RegisterSocket(Socket socket)
            {
                if (DoRegistrationChecks)
                {
                    if (socket.CpuPins == null || socket.CpuPins.Length != 11) SocketRegistrationError(socket, "CpuPins array must be of length 11");
                    if (socket.SupportedTypes == null || socket.SupportedTypes.Length == 0) SocketRegistrationError(socket, "SupportedTypes list is null/empty");
                    foreach (char type in socket.SupportedTypes)
                    {
                        switch (type)
                        {
                            case 'A':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6 }, type);
                                if (socket.AnalogInput3 == null || socket.AnalogInput4 == null || socket.AnalogInput5 == null) SocketRegistrationError(socket, "Socket of type A must support analog input functionality on pins 3, 4 and 5");
                                break;
                            case 'C':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6 }, type);
                                break;
                            case 'D':
                                TestPinsPresent(socket, new int[] { 3, 6, 7 }, type);
                                break;
                            case 'E':
                                TestPinsPresent(socket, new int[] { 6, 7, 8, 9 }, type);
                                break;
                            case 'F':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6, 7, 8, 9 }, type);
                                break;
                            case 'H':
                                TestPinsPresent(socket, new int[] { 3 }, type);
                                break;
                            case 'I':
                                TestPinsPresent(socket, new int[] { 3, 6, 8, 9 }, type);
                                break;
                            case 'K':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6, 7 }, type);
                                if (socket.SerialPortName == null) SocketRegistrationError(socket, "Socket of type K must specify serial port name");
                                break;
                            case 'O':
                                TestPinsPresent(socket, new int[] { 3, 4, 5 }, type);
                                if (socket.AnalogOutput == null) SocketRegistrationError(socket, "Socket of type O must support analog output functionality");
                                break;
                            case 'P':
                                TestPinsPresent(socket, new int[] { 3, 6, 7, 8, 9 }, type);
                                if (socket.PWM7 == null || socket.PWM8 == null || socket.PWM9 == null) SocketRegistrationError(socket, "Socket of type P must support PWM functionality");
                                break;
                            case 'S':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6, 7, 8, 9 }, type);
                                if (socket.SPIModule == Socket.SPIMissing) SocketRegistrationError(socket, "Socket of type S must specify SPI module number");
                                break;
                            case 'T':
                                TestPinsPresent(socket, new int[] { 4, 5, 6, 7 }, type);
                                break;
                            case 'U':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6 }, type);
                                if (socket.SerialPortName == null) SocketRegistrationError(socket, "Socket of type U must specify serial port name");
                                break;
                            case 'R':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6, 7, 8, 9 }, type);
                                break;
                            case 'G':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6, 7, 8, 9 }, type);
                                break;
                            case 'B':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6, 7, 8, 9 }, type);
                                break;
                            case 'X':
                                TestPinsPresent(socket, new int[] { 3, 4, 5 }, type);
                                break;
                            case 'Y':
                                TestPinsPresent(socket, new int[] { 3, 4, 5, 6, 7, 8, 9 }, type);
                                break;
                            case 'Z':
                                // manufacturer specific socket - no tests
                                break;
                            case '*':
                                // * is a special case  - daisylink modules don't actually declare their new socket in code, instead reusing the mainboard socket number 
                                // so we don't need the below, but it doesnt hurt to leave it in
                                TestPinsPresent(socket, new int[] { 3, 4, 5 }, type);
                                break;
                            default:
                                SocketRegistrationError(socket, "Socket type '" + type + "' is not supported by Gadgeteer");
                                break;
                        }
                    }
                }

                lock (Socket._sockets)
                {
                    if (Socket.GetSocket(socket.SocketNumber, false, null, null) != null) throw new Socket.InvalidSocketException("Cannot register socket - socket number " + socket.SocketNumber + " already used");
                    Socket._sockets.Add(socket);
                    socket._registered = true;
                }
            }

            /// <summary>
            /// Delegate for mainboards to provide custom native/hardware I2C support. 
            /// </summary>
            /// <param name="socket">The socket.</param>
            /// <param name="sda">The socket pin for the SDA signal.</param>
            /// <param name="scl">The socket pin for the SCL signal.</param>
            /// <param name="address">The address to which to send the result.</param>
            /// <param name="write">The data buffer to write.</param>
            /// <param name="writeOffset">The offset in the buffer where writing begins (this can be null if no data is to be written).</param>
            /// <param name="writeLen">The number of bytes of data to write.</param>
            /// <param name="read">The data buffer that data is put into after a read operation (this can be null if no data is to be read).</param>
            /// <param name="readOffset">The offset to start writing data after a read operation.</param>
            /// <param name="readLen">The amount of data to read.</param>
            /// <param name="numWritten">The number of bytes actually written and acknowledged.</param>
            /// <param name="numRead">The number of bytes actually read.</param>
            /// <returns>Returns true if the whole transaction succeeds, otherwise false.</returns>
            public delegate bool NativeI2CWriteReadDelegate(Socket socket, Socket.Pin sda, Socket.Pin scl, byte address, byte[] write, int writeOffset, int writeLen, byte[] read, int readOffset, int readLen, out int numWritten, out int numRead);

            /// <summary>
            /// Provides access to a socket's pulse width modulation (PWM) functionality.
            /// </summary>
            public interface PWM
            {
                /// <summary>
                /// Set the PWM function to use a specified frequency and duty cycle.
                /// </summary>
                /// <param name="frequency">The frequency in Hz.</param>
                /// <param name="dutyCycle">The duty cycle, i.e. how much of the time the signal is "high" or "low".</param>
                void Set(int frequency, byte dutyCycle);

                /// <summary>
                /// Set the PWM function to use a particular period, with a given high time high within that period (low time would be period-high_time)
                /// </summary>
                /// <param name="period_ns">The period, in nanoseconds</param>
                /// <param name="highTime_ns">The high time, in nanoseconds</param>
                void SetPulse(uint period_ns, uint highTime_ns);

                /// <summary>
                /// A property to control whether the PWM functionality is active or not.
                /// </summary>
                bool Active { get; set; }
            }

            /// <summary>
            /// Provides access to a socket's analog output functionality.
            /// </summary>
            public interface AnalogOutput
            {
                /// <summary>
                /// Specifies the minimum voltage that this analog output supports.
                /// </summary>
                double MinOutputVoltage { get; }

                /// <summary>
                /// Specifies the maximum voltage that this analog output supports.
                /// </summary>
                double MaxOutputVoltage { get; }

                /// <summary>
                /// Sets the voltage output by this analog output.
                /// </summary>
                /// <param name="value">The voltage to output</param>
                void SetVoltage(double value);

                /// <summary>
                /// A property to control whether the analog output functionality on this socket is active or not.
                /// </summary>
                bool Active { get; set; }
            }

            /// <summary>
            /// An interface to a socket's analog input functionality.
            /// </summary>
            public interface AnalogInput
            {

                /// <summary>
                /// Reads the voltage on the analog input (0V to 3.3V)
                /// </summary>
                /// <returns>The voltage from 0 to 3.3</returns>
                double ReadVoltage();

                /// <summary>
                /// A property to control whether the analog input functionality is active or not.
                /// </summary>
                bool Active { get; set; }
            }
        }
    }
    
}