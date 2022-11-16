from selenium import webdriver
from selenium.webdriver.chrome.service import Service

base_url = "https://www.amazon.com"
exe_path = r"E:\HK1_Nam4\SoftwareTesting\Record\demo\chrome\chromedriver.exe"

service = Service(exe_path)
options = webdriver.ChromeOptions()
driver = webdriver.Chrome(service=service, options=options)

driver.maximize_window()

driver.implicitly_wait(10) #seconds

driver.get(base_url)

assert "abc" in driver.title

driver.close()
