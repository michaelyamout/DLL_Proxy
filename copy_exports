import pefile

# Specify the input and output DLL files
input_dll = "input.dll"
output_dll = "output.dll"

# Open the input DLL file and extract the exports
pe = pefile.PE(input_dll)
exports = pe.DIRECTORY_ENTRY_EXPORT.symbols

# Open the output DLL file and update its exports
pe = pefile.PE(output_dll)

# Update the existing exports with the ones from the input DLL
for i, export in enumerate(pe.DIRECTORY_ENTRY_EXPORT.symbols):
    if i < len(exports):
        export.name = exports[i].name
        export.address = exports[i].address

# Add any additional exports from the input DLL
if len(exports) > len(pe.DIRECTORY_ENTRY_EXPORT.symbols):
    for export in exports[len(pe.DIRECTORY_ENTRY_EXPORT.symbols):]:
        pe.DIRECTORY_ENTRY_EXPORT.symbols.append(export)

# Save the modified DLL file
pe.write(output_dll)
