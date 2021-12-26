i = 0
while i == 0:
  file1 = open('APPMAKE', 'r')
  Lines = file1.readlines()
 
  count = 0
  checkpoint = 0
  ccount = 1
  # Strips the newline character
  for line in Lines:
      count += 1
      ccount += 1
      modeset += 1
      if ccount > checkpoint:
        checkpoint += 1
        if modeset > 2:
           modeset == 1
        if modeset == 1:
           elfexecutable = line
        if modeset == 2:
           appname = line
           checkpoint = count + 1
           break
  #writing data
  file1.close()
  file2 = open(appname + ".app", "a")  # append mode
  file2.write(elfexecutable + "\n")
  file2.close()
    
    
