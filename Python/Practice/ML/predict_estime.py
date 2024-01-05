import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import StandardScaler
from sklearn.metrics import mean_squared_error, r2_score

excel_file_path = 'data_store/route_data.xlsx'
df = pd.read_excel(excel_file_path)

df.dropna(inplace=True)
df['RouteId'] = df['RouteId'].map({'V-1': 0, 'V-2': 1})
df['StationId'] = pd.to_numeric(df['StationId'].str.slice(1), errors='coerce')
df['DestStationId'] = pd.to_numeric(df['DestStationId'].str.slice(1), errors='coerce')

X = df[['Name', 'Lat', 'Lng', 'Speed', 'HeadingAngle', 'RouteId', 'Direction', 'StationId', 'DestStationId']]
y = df[['Distance', 'EstimateTime']]

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

scaler = StandardScaler()
X_train_scaled = scaler.fit_transform(X_train)
X_test_scaled = scaler.transform(X_test)

model = LinearRegression()
model.fit(X_train_scaled, y_train)

y_pred = model.predict(X_test_scaled)

mse = mean_squared_error(y_test, y_pred)
r2 = r2_score(y_test, y_pred)

print(f'Mean Squared Error: {mse}')
print(f'R-squared: {r2}')
