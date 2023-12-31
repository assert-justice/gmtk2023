extends Node

var data: Dictionary = {}

# Called when the node enters the scene tree for the first time.
func _ready():
	var src := load("res://lines.json")
	data = src.data


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
	#pass

func get_message(key, random, destructive):
	if data.has(key):
		var text = data[key]
		if typeof(text) == TYPE_DICTIONARY:
			if(destructive):
				data.erase(key)
			return text
		elif typeof(text) == TYPE_ARRAY:
			var arr: Array = text
			if len(arr) == 0:
				return null
			var idx = 0
			if random:
				idx = randi_range(0, len(arr) - 1)
			var res = arr[idx]
			if destructive:
				arr.remove_at(idx)
			if not random and not destructive:
				arr.remove_at(idx)
				arr.push_back(res)
			return res
	return null
