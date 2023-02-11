export async function AddWidgetCity (data) {
  const response = await fetch('back/api/city', {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  })
  return await response.json()
}
export async function AddWidgetApod (data) {
  const response = await fetch('back/api/apod', {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  })
  return await response.json()
}
export async function AddWidgetTimer (data) {
  const response = await fetch('back/api/timer', {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  })
  return await response.json()
}
export async function AddWidgetArtist (data) {
  const response = await fetch('back/api/artist', {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  })
  return await response.json()
}
export async function getWidgetdata () {
  const response = await fetch('back/api/users')
  return await response.json()
}
