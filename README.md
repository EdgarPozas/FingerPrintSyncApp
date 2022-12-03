# FingerPrintSyncApp

Aplicación de Windows que sincroniza la información de una API a dispositivos ZKTeco conectados en la red.

## Software de terceros

- Newtonsoft JSON
- ZKemkeeper

## API

Petición
`GET http://example.com/finger_print_sensors/online`

Respuesta

```
{
    code: 200
}
```

Petición
`GET http://example.com/finger_print_sensors/configurate`

Respuesta

```
{
    code: 200,
    msg: 'Ok',
    data: {
        time: '2022-12-02 20:20',
        time_zone: 'Mazatlan',
        sensors:[
            {
                id: 1,
                name: 'Lector principal',
                serial_number: 'XXXXXXXXXXXX',
                admin_password: '1234'
            }
        ]
    }
}
```

Petición
`GET http://example.com/finger_print_sensors/list_employees`

Respuesta

```
{
    msg: 'Ok',
    data:[
        {
            employee_number: 1,
            name: 'User 1',
            pin_code: '1234',
            card_code: '1239896982',
            finger_prints: [
                {
                    finger_index: 6,
                    template: 'AAsvvmadlkjnalnvxcbabs123kmsjhdbkjn.....'
                }
            ]
        }
    ]
}
```

Petición
`POST http://example.com/finger_print_sensors/synchronize`

Respuesta

```
{
    Users: [
        {
            SerialNumber: 'XXXXXXXXXXXX',
            MachineNumber: 'XXXXXXXXXXXX',
            EnrollNumber: '1',
            Name: 'User 1',
            Password: '1234',
            Privelage: 1,
            Enabled: true,
            Flag: 1,
            CardCode: '1223548823',
            Fingers: [
                {
                    finger_index: 6,
                    template: 'AAsvvmadlkjnalnvxcbabs123kmsjhdbkjn.....'
                }
            ]
        }
    ],
    Logs: [
        {
            SerialNumber: 'XXXXXXXXXXXX',
            MachineNumber: 'XXXXXXXXXXXX',
            InOutMode: '1',
            VerifyMode: '1',
            CheckTime: '2022-12-02T20:20',
            WorkCode: 1
        }
    ]
}
```

## Imagenes

![General](https://github.com/EdgarPozas/FingerPrintSyncApp/blob/main/images/GENERAL.png)

![Connect](https://github.com/EdgarPozas/FingerPrintSyncApp/blob/main/images/Connect.png)

![Devices](https://github.com/EdgarPozas/FingerPrintSyncApp/blob/main/images/Devices.png)

![DataBase](https://github.com/EdgarPozas/FingerPrintSyncApp/blob/main/images/DataBase.png)

![Logs](https://github.com/EdgarPozas/FingerPrintSyncApp/blob/main/images/Logs.png)

![Configuration](https://github.com/EdgarPozas/FingerPrintSyncApp/blob/main/images/Configuration.png)

```

```
