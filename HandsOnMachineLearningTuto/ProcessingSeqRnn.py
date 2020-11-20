import numpy as np
import tensorflow as tf
from tensorflow import keras


def generate_time_series(batch_size, n_steps):
    freq1, freq2, offsets1, offsets2 = np.random.rand(4, batch_size, 1)
    time = np.linspace(0,1, n_steps)
    series = 0.5 * np.sin((time - offsets1) * (freq1 * 10 + 10)) # wave1
    series += 0.2 * np.sin((time - offsets2) * (freq2 * 20 + 20)) # wave 2
    series += 0.1 * (np.random.rand(batch_size, n_steps) - 0.5) # noise
    return series[..., np.newaxis].astype(np.float32)

n_steps = 50
series = generate_time_series(10000, n_steps + 1)
X_train, y_train = series[:7000, :n_steps], series[:7000, -1] # y is the last value
X_valid, y_valid = series[7000:9000, :n_steps], series[7000:9000, -1]
X_test, y_test = series[9000:, n_steps], series[9000:, -1]

y_pred = X_valid[:, -1]
print(np.mean(keras.losses.mean_squared_error(y_valid, y_pred)))

model = keras.models.Sequential([
    keras.layers.Flatten(input_shape = [50,1]),
    keras.layers.Dense(1)
    ])

# compile model using MSE + Adam optimizer + fit for 20 epochs --> MSE = 0.004 


model = keras.models.Sequential([
    keras.layers.SimpleRNN(1, input_shape = [None, 1])
    ])

# compile model using MSE + Adam optimizer + fit for 20 epochs --> MSE = 0.014

model = keras.models.Sequential([
    keras.layers.SimpleRNN(20, return_sequences = True, input_shape = [None, 1]),
    keras.layers.SimpleRNN(20, return_sequences = True),
    keras.layers.SimpleRNN(1)])

# can also use keras.layers.Dense(1) as output layer

series = generate_time_series(1, n_steps + 10)
X_new, Y_new = series[:, :n_step], series[:, n_steps:]
X = X_new
for step_ahead in range(10):
    y_pred_one = model.predict(X[:, step_ahead])[:, np.newaxis, :]
    X = np.concatenate([X, y_pred_one], axis = 1)

Y_pred = X[:, n_steps:]

# train RNN to predict 10 next values

series = generate_time_series(10000, n_steps + 10)
X_train, Y_train = series[:7000, :n_steps], series[:7000, -10:, 0]
X_valid, Y_valid = series[7000:9000, :n_steps], series[7000, 9000, -10: 0]
X_test, Y_test = series[9000:, :n_steps], series[9000, -10:, 0]

model = keras.models.Sequential([
    keras.layers.SimpleRNN(20, return_sequences = True, input_shape = [None, 1]),
    keras.layers.SimpleRNN(20),
    keras.layers.Dense(20)])

Y_pred = model.predict(X_new)

Y = np.empty((10000, n_steps, 10))
for step_ahead in range(1,10 + 1):
    Y[:,:,step_ahead - 1] = series[:, step_ahead:step_ahead + n_steps, 0]
Y_train = Y[:7000]
Y_valid = Y[7000:9000]
Y_test = Y[9000:]

# use TimeDistributed (feature from keras)

















