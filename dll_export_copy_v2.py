import sys
import os
import argparse
import pefile

def copy_exports(input_path, output_path):
    # Open the input and output DLL files using pefile
    input_dll = pefile.PE(input_path)
    output_dll = pefile.PE(output_path)

    # Copy the exports from the input DLL to the output DLL
    for exp in input_dll.DIRECTORY_ENTRY_EXPORT.symbols:
        exp_name = exp.name.decode()
        exp_address = exp.address

        # Add the export to the output DLL
        output_dll.DIRECTORY_ENTRY_EXPORT.add_export(pefile.ExportedSymbol(exp_name, exp_address))

    # Save the output DLL file
    output_dll.write(filename=output_path)

if __name__ == "__main__":
    # Define the command line arguments
    parser = argparse.ArgumentParser(description='Copy exports from one DLL file to another.')
    parser.add_argument('input', metavar='input', type=str, help='the input DLL file path')
    parser.add_argument('output', metavar='output', type=str, help='the output DLL file path')

    # Check if the user requested help
    if "--help" in sys.argv or "-h" in sys.argv:
        parser.print_help()
        sys.exit()

    # Parse the command line arguments
    args = parser.parse_args()
    input_path = args.input
    output_path = args.output

    # Check if the input DLL file exists
    if not os.path.isfile(input_path):
        print("Error: The input file does not exist.")
        sys.exit()

    # Execute the DLL export copy function
    copy_exports(input_path, output_path)

    print(f"Exports copied from {input_path} to {output_path}.")
