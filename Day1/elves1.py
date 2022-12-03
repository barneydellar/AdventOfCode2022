
elves = [0]
with open(r"C:\Users\Barnaby.Dellar\OneDrive - Canon Medical Research Europe Limited\Desktop\elves.txt") as file_in:
    elf_count = 0
    for line in file_in:
        line = line.strip()
        if line == "":
            elf_count += 1
            elves.append(0)
        else:
            elves[elf_count] += int(line)
elves = sorted(elves, reverse=True)
top_three = elves[:3]

print("The sum of the top three elves is " + str(sum(top_three)) + ".")