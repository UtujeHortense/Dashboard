export async function AddDeezerToken (data) {
  const response = await fetch('back/api/deezertoken', {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  })
  return await response.json()
}
