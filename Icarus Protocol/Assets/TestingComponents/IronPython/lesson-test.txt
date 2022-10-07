testVar = 0

def double(value):
	return value * 2

def simulate():
	global testVar
	parent.execute_user_code()
	if testVar > 20:
		parent.end_simulation(1)
	elif testVar < -20:
		parent.end_simulation(0)

def simulate_tick():
	global testVar
	testVar = testVar + 0.01
	return testVar