from enigma.machine import EnigmaMachine

machineEnc = EnigmaMachine.from_key_sheet(
       rotors='II III V',
       reflector='C',
       ring_settings=[1, 20, 11],
       plugboard_settings='AV BS CG DL FU HZ IN KM OW RX')

# Кот дня
machineEnc.set_display('ZXC')
# Секретный ключ
msg_key = machineEnc.process_text('KCH')
print('msg key result: ' + msg_key)

ciphertext = 'SIARHEIXSIARHEYEU'

machineEnc.set_display('KCH')

plaintext = machineEnc.process_text(ciphertext)

print('Encrypted: ' + plaintext)

machineDec = EnigmaMachine.from_key_sheet(
       rotors='II III V',
       reflector='C',
       ring_settings=[1, 20, 11],
       plugboard_settings='AV BS CG DL FU HZ IN KM OW RX')

machineDec.set_display('ZXC')

# расшифровываем секретный ключ
msg_key = machineDec.process_text(msg_key)

print('msg key result 2 '+msg_key)

machineDec.set_display(msg_key)

plaintext = machineDec.process_text(plaintext)

print('Decrypted: ' + plaintext)
