import requests
import json
from YelpAPIKey import get_my_key

apiKey = get_my_key()
endpoint = "https://api.yelp.com/v3/categories"
headers = {'Authorization': 'bearer %s' % apiKey}

#make requests
response = requests.get(url = endpoint, headers = headers)

#convert json to dictionary obj
business_data = response.json()

#alias name is always lowercase with no space
for item in business_data['categories']:
    print(item['title'])





#print(json.dumps(business_data, indent = 3))

