def zoomIn():
    click("1616407498461.png")
    wait("1616408950203.png")
    click("1616407609917.png")
    wait("1616409049969.png")
    click("1616407648440.png")


def zoomOut():
    click("1616407498461.png")
    wait("1616408950203.png")
    click("1616407609917.png")
    wait("1616407752029.png")
    click("1616407752029.png")



def getZoom():
    reg = Region(Region(907,900,49,21))
    return reg.text()


def saveDocument():
    click("1616409529273.png")
    wait("1616409548821.png")
    click("1616409548821.png")
    wait("1616409630691.png")
    paste('C:\\Users\\blakk\\OneDrive\\Desktop\\test.txt')
    click("1616409836727.png")


def readDocument():
    reg = Region(Region(34,143,372,353))
    return reg.text()


def deleteDocument(file):
    file.rightClick()
    wait("1616412858061.png")
    click("1616412858061.png")


app = App('C:/Windows/System32/notepad.exe')
app.open()
app.focus()

assert getZoom() == '100%'
zoomIn()
assert getZoom() == '110%'
zoomOut()
zoomOut()
assert getZoom() == '90%'

_text = 'Hello World!'
type(_text)
saveDocument()
app.close()

file = exists("1616410550424.png")
file.doubleClick()
wait("1616411902239.png")

assert readDocument() == _text

app.close()

deleteDocument(file)
