import numpy as np
import tensorflow as tf
from tensorflow import keras

shakespeare_url = "https://homl.info/shakespeare"
filepath = keras.utils.get_file("shakespeare.txt", shakespeare_url)
with open(filepath) as f:
    shakespeare_text = f.read()

# we must encode every character as an integer

tokenizer = keras.preprocessing.text.Tokenizer(char_level = True)
tokenizer.fit_on_texts([shakespeare_text])

print(tokenizer.texts_to_sequences(["First"]))
print(tokenizer.sequences_to_texts([[20, 6, 9, 8 , 3]]))

[encoded] = np.array(tokenizer.texts_to_sequences([shakespeare_text])) - 1

train_size = dataset_size * 90 // 100
dataset = tf.data.Dataset.from_tensor_slices(encoded[:train_size])

