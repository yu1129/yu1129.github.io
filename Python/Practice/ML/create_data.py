import requests
import os
import pandas as pd
import time

api_url = ""
api_key = ""

data_store_folder = "data_store"
excel_file_path = os.path.join(data_store_folder, "route_data.xlsx")

os.makedirs(data_store_folder, exist_ok=True)

first_iteration = False

if not os.path.exists(excel_file_path):
    first_iteration = True

total_execution_time = 0

while True:
    try:
        start_time = time.time()

        headers = {"ApiKey": api_key}
        response = requests.get(api_url, headers=headers, verify=False)

        if response.status_code == 200:
            data = response.json()
        else:
            print(f"API 請求失敗，狀態碼：{response.status_code}")

        mydata = data["Data"]

        df = pd.DataFrame(mydata)

        df[["Lat", "Lng"]] = pd.DataFrame(df['LatLng'].tolist(), index=df.index)

        selected_columns = ['Name', 'Lat', 'Lng', 'Speed', 'StationId', 'DestStationId', 'EstimateTime', 'Distance', 'HeadingAngle', 'RouteId', 'Direction']

        filtered_df = df[selected_columns]
        filtered_df = filtered_df[((filtered_df['StationId'] != 'V00') & (filtered_df['DestStationId'] != 'V00')) | ((filtered_df['DestStationId'] == filtered_df['StationId']) & (filtered_df['Speed'] != 0))]

        if first_iteration:
            filtered_df.to_excel(excel_file_path, index=False, sheet_name='Sheet1')
            first_iteration = False
        else:
            with pd.ExcelWriter(excel_file_path, engine='openpyxl', mode='a', if_sheet_exists='overlay') as writer:
                filtered_df.to_excel(writer, index=False, header=False, startrow=writer.sheets['Sheet1'].max_row, sheet_name='Sheet1', startcol=0)

        end_time = time.time()
        execution_time = end_time - start_time
        total_execution_time += execution_time

        print(f"資料已成功寫入 {excel_file_path}，執行時間: {execution_time:.2f} 秒，總執行時間: {total_execution_time:.2f} 秒")
        time.sleep(1)

    except Exception as e:
        print(f"發生錯誤：{e}")
        time.sleep(1)
