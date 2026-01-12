IL2CPPFolder="K:\SteamLibrary\steamapps\common\Schedule I\MelonLoader\Il2CppAssemblies"
NETFolder="K:\SteamLibrary\steamapps\common\Schedule I\MelonLoader\Managed"

dependencies=()
filesIL2CPP=()
filesNET=()
allFiles=()

while IFS= read -r line; do
	if [[ $line =~ \<HintPath\>.* ]]; then
		line="${line#"${line%%[![:space:]]*}"}"
		line=${line:10}
		line=${line::-12}
		dependencies+=("$line")
	fi
done < AutomatedTasksMod.csproj

for file in "$IL2CPPFolder"/*; do
	filesIL2CPP+=("${file/\//\\}")
done

for file in "$NETFolder"/*; do
	filesNET+=("${file/\//\\}")
done

allFiles=( "${filesIL2CPP[@]}" "${filesNET[@]}" )

readarray -td '' dependencies < <(printf '%s\0' "${dependencies[@]}" | sort -z)
readarray -td '' allFiles < <(printf '%s\0' "${allFiles[@]}" | sort -z)

# printf '%s\n' "${dependencies[@]}"
# printf '%s\n' "${allFiles[@]}"

# printf '%s\n' "${dependencies[@]}" "${allFiles[@]}" | sort | uniq -u

echo "Files that aren't in dependencies:"

anyFound=0

for file in "${allFiles[@]}"; do
	found=0

	for line in "${dependencies[@]}"; do
		if [[ "$file" == "$line" ]]; then
			found=1
			anyFound=1
			break
		fi
	done
	
	if [ $found -eq "0" ]; then
		echo "    $file"
	fi
done

if [ $anyFound -eq "0" ]; then
	echo "    None"
fi

echo
echo "Dependencies that aren't in files:"

anyFound=0

for line in "${dependencies[@]}"; do
	found=0

	for file in "${allFiles[@]}"; do
		if [[ "$file" == "$line" ]]; then
			found=1
			anyFound=1
			break
		fi
	done
	
	if [ $found -eq "0" ]; then
		echo "    $line"
	fi
done

if [ $anyFound -eq "0" ]; then
	echo "    None"
fi

echo

read -n 1 -r -p "Press any key to quit..." key