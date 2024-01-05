import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn.preprocessing import StandardScaler
from sklearn.metrics import accuracy_score, classification_report, confusion_matrix
from sklearn.multioutput import MultiOutputClassifier

excel_file_path = 'data_store/route_data.xlsx'
df = pd.read_excel(excel_file_path)

df.dropna(inplace=True)
df['RouteId'] = df['RouteId'].map({'V-1': 0, 'V-2': 1})

X = df[['Name', 'Lat', 'Lng', 'Speed', 'HeadingAngle', 'RouteId', 'Direction']]
y = df[['StationId', 'DestStationId']]

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

scaler = StandardScaler()
X_train_scaled = scaler.fit_transform(X_train)
X_test_scaled = scaler.transform(X_test)

base_model = DecisionTreeClassifier()
multi_output_model = MultiOutputClassifier(base_model, n_jobs=-1)

multi_output_model.fit(X_train_scaled, y_train)

y_pred = multi_output_model.predict(X_test_scaled)

accuracy_start = accuracy_score(y_test['StationId'], y_pred[:, 0])
accuracy_end = accuracy_score(y_test['DestStationId'], y_pred[:, 1])

print(f'Accuracy StationId: {accuracy_start}')
print(f'Accuracy DestStationId: {accuracy_end}')

for target_index, target_name in enumerate(['StationId', 'DestStationId']):
    print(f'\nTarget: {target_name}')
    print('Classification Report:\n', classification_report(y_test.iloc[:, target_index], y_pred[:, target_index]))
    print('Confusion Matrix:\n', confusion_matrix(y_test.iloc[:, target_index], y_pred[:, target_index]))
