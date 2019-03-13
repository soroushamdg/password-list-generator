filename = str(input("enter file name to save : "))
username = input("write username : ")
howToWrite = str(input("write model1 : 'username:password' or model2 : 'password' (1,2) : "))
letters = list("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ")
numbers = list("0123456789 ")
customChars = list(input("insert your custom chars (exp : !@#$%) : "))
allChars = []
letterAv = str(input("letters available (y,n) : "))
allChars.extend(customChars)
if letterAv == 'n':
	letterAv = False
else:
	letterAv = True
	allChars.extend(letters)
numberAv = str(input("numbers available (y,n) : "))
if numberAv == 'n':
	numberAv = False
else:
	numberAv = True
	allChars.extend(numbers)
print(len(allChars))
searchRangeStart = int(input("search range start : "))
searchRangeEnd = int(input("search range End : "))
strs = []
allActions = 0
number = 0
print("preparing...")
for i in range(searchRangeStart,searchRangeEnd+1):
	allActions+=pow(len(allChars),i)
print(allActions)
def printProgress(number):
	percent = (number/allActions)*100
	print(str(percent)+" percent completed,"+str(number)+" records found.")
def completeStage(number):
	print("stage %s completed",str(number))
f = open(filename+".txt", "a")
print("starting progress...\nthis action may take too long...")
for r1 in range(searchRangeStart,searchRangeEnd+1):
	counterlist = list(range(0,r1))
	for a in range(0,r1):
		counterlist[a] = 0
	def counter():
		global counterlist
		for p in range(0,r1):
			i = r1-p-1
			print(i)
			if counterlist[i]==len(allChars)-1:
				if i-1>=0:
					counterlist[i-1]+=1
					counterlist[i]=0
				else:
					return

		counterlist[r1-1]+=1
	for b in range(0,pow(len(allChars),r1)):
		strk = list(range(0,r1))
		for c in range(0,r1):
			strk[c] = allChars[counterlist[c]]
		counter()
		print(''.join(strk))
		print("writing to file...")
		if howToWrite == '1':
			f.write(username+":"+strk+"\n")
		else:
			f.write(''.join(strk)+"\n")
		number += 1
		printProgress(number)
print("finished finding...")
print("progress completed...")